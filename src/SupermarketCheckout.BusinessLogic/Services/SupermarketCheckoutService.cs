using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SupermarketCheckout.BusinessLogic.Tests")]
namespace SupermarketCheckout.BusinessLogic.Services
{
    using AutoMapper;
    using SupermarketCheckout.BusinessLogic.Models;
    using SupermarketCheckout.Common.Exceptions;
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Concrete implementation of a supermarket checkout 
    /// </summary>
    public class SupermarketCheckoutService : ISupermarketCheckoutService
    {
        readonly IDiscountRepository _discountRepository;
        readonly IPriceRepository _priceRepository;
        readonly IArticleRepository _articleRepository;        
        readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discountRepository">it holds the discount information about an article</param>
        /// <param name="priceRepository">it holds the single price of an article</param>
        public SupermarketCheckoutService(IDiscountRepository discountRepository, IPriceRepository priceRepository, IArticleRepository articleRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _priceRepository = priceRepository;
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        internal async Task ValidateBasket(ShoppingBasketDto basket)
        {
            if (basket == null || basket.Articles == null || !basket.Articles.Any()) throw new InvalidBasketException("Basket is empty");

            foreach (var item in basket.Articles)
            {
                var articleDto = item.Article;
                var articleDiscountDto = item.ArticleDiscount;
                var articlePriceDto = item.ArticlePrice;
                var numberOfArticlesDto = item.NumberOfArticles;

                // check number of articles
                if (!numberOfArticlesDto.HasValue)
                    throw new InvalidBasketException("Number of articles is invalid");

                // check discount
                if (articleDiscountDto != null)
                {
                    ArticleDiscount articleDiscount = await _discountRepository.GetByIdAsync(articleDiscountDto.Id.Value).ConfigureAwait(false);
                    var articleDiscountDbDto = _mapper.Map<ArticleDiscountDto>(articleDiscount);
                    if (!articleDiscountDbDto.Equals(articleDiscountDto))
                        throw new InvalidDiscountException("ArticleDiscount is invalid");
                }

                // check article
                Article article = await _articleRepository.GetByIdAsync(articleDto.Id.Value).ConfigureAwait(false);
                var articleDbDto = _mapper.Map<ArticleDto>(article);
                if (!articleDbDto.Equals(articleDto))
                    throw new InvalidArticleException("Article is invalid");

                // check articlePrice
                var articlePrice = await _priceRepository.GetByIdAsync(articlePriceDto.Id.Value).ConfigureAwait(false);
                var articlePriceDbDto = _mapper.Map<ArticlePriceDto>(articlePrice);
                if (!articlePriceDbDto.Equals(articlePriceDto))
                    throw new InvalidArticlePriceException("ArticlePrice is invalid");
            }
        }

        /// <inheritdoc />
        public async Task<BillDto> CreateBill(ShoppingBasketDto basket)
        {
            var bill = new BillDto
            {
                TotalPrice = 0
            };

            try
            {
                await ValidateBasket(basket).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new InvalidBasketException("Invalid Basket", ex);
            }
            foreach (var item in basket.Articles)
            {
                var articleDto = item.Article;
                var articleDiscountDto = item.ArticleDiscount;
                var articlePriceDto = item.ArticlePrice;
                var numberOfArticlesDto = item.NumberOfArticles;
                var article = _mapper.Map<Article>(articleDto);
                var articleDiscount = _mapper.Map<ArticleDiscount>(articleDiscountDto);

                bill.TotalPrice += CalculatePrice(numberOfArticlesDto.Value, articlePriceDto.UnitPrice.Value, articleDiscount);
            }
            return bill;
        }

        internal decimal CalculatePrice(int numberOfArticles, decimal itemPrice, ArticleDiscount articleDiscount)
        {
            decimal price = 0;
            int currentNumberOfArticles = numberOfArticles;

            // 1st try to use the discount price for as much items as possible
            while (articleDiscount != null && articleDiscount.NumberOfArticles != 0 && currentNumberOfArticles >= articleDiscount.NumberOfArticles)
            {
                price += articleDiscount.NewPrice;
                currentNumberOfArticles -= articleDiscount.NumberOfArticles;
            }

            // 2nd use the common single item price 
            if (currentNumberOfArticles > 0)
                price += currentNumberOfArticles * itemPrice;

            return price;
        }
    }
}
