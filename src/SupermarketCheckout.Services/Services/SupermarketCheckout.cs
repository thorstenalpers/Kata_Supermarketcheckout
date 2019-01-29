using SupermarketCheckout.Contracts;
using SupermarketCheckout.Repositories.Contracts;
using SupermarketCheckout.Repositories.Model;
using SupermarketCheckout.Services.Model;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SupermarketCheckout.Services.Tests")]
namespace SupermarketCheckout.Services
{
    /// <summary>
    /// Concrete implementation of a supermarket checkout 
    /// </summary>
    public class SupermarketCheckout : ISupermarketCheckout
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IPriceRepository _priceRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discountRepository">it holds the discount information about an article</param>
        /// <param name="priceRepository">it holds the single price of an article</param>
        public SupermarketCheckout(IDiscountRepository discountRepository, IPriceRepository priceRepository)
        {
            _discountRepository = discountRepository;
            _priceRepository = priceRepository;
        }

        /// <inheritdoc />
        public Bill CreateBill(Basket basket)
        {
            var discountList = _discountRepository.GetDiscountList();
            var priceList = _priceRepository.GetPriceList();
            var bill = new Bill();

            foreach (var item in basket.MapArticlesToNumber)
            {
                var article = item.Key;
                var numberOfArticles = item.Value;

                var itemDiscount = discountList.FirstOrDefault(e => e.Article == article);
                var itemPrice = priceList.FirstOrDefault(e => e.Article == article);
                if (itemPrice == null)
                    throw new Exception("Cant retrieve a price for an article");

                bill.TotalPrice += CalculatePrice(numberOfArticles, itemPrice.Price, itemDiscount);
            }
            return bill;
        }
        
        internal decimal CalculatePrice(uint numberOfItems, decimal itemPrice, ArticleDiscount articleDiscount)
        {
            decimal price = 0;
            uint currentNumberOfItems = numberOfItems;

            // 1st try to use the discount price for as much items as possible
            while (articleDiscount != null && articleDiscount.NumberOfItems != 0 && currentNumberOfItems >= articleDiscount.NumberOfItems)
            {
                price += articleDiscount.NewPrice;
                currentNumberOfItems -= articleDiscount.NumberOfItems;
            }

            // 2nd use the common single item price 
            if (currentNumberOfItems > 0)
                price += currentNumberOfItems * itemPrice;

            return price;
        }
    }
}
