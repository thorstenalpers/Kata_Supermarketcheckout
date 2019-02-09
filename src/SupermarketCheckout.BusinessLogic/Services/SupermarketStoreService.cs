namespace SupermarketCheckout.BusinessLogic.Services
{
    using AutoMapper;
    using Models;
    using SupermarketCheckout.DataAccess.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SupermarketStoreService : ISupermarketStoreService
    {
        readonly IDiscountRepository _discountRepository;
        readonly IPriceRepository _priceRepository;
        readonly IArticleRepository _articleRepository;
        readonly IMapper _mapper;

        public SupermarketStoreService(IDiscountRepository discountRepository, IPriceRepository priceRepository, IArticleRepository articleRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _priceRepository = priceRepository;
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ArticleDto>> GetAllArticles()
        {
            var list = await _articleRepository.ListAllAsync().ConfigureAwait(false);
            return _mapper.Map<IReadOnlyList<ArticleDto>>(list);
        }

        public async Task<IReadOnlyList<ArticleDiscountDto>> GetAllDiscounts()
        {
            var list = await _discountRepository.ListAllAsync().ConfigureAwait(false);
            return _mapper.Map<IReadOnlyList<ArticleDiscountDto>>(list);
        }

        public async Task<IReadOnlyList<ArticlePriceDto>> GetAllPrices()
        {
            var list = await _priceRepository.ListAllAsync().ConfigureAwait(false);
            return _mapper.Map<IReadOnlyList<ArticlePriceDto>>(list);
        }
    }
}
