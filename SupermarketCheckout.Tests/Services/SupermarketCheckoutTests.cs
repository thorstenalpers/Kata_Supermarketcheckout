using NUnit.Framework;
using SupermarketCheckout.Common.Model;
using SupermarketCheckout.Repositories.Model;
using SupermarketCheckout.Repositories.Repositories;
using SupermarketCheckout.Services.Model;

namespace SupermarketCheckout.Services.Tests.Services
{
    /// <summary>
    /// integration + unit tests
    /// </summary>
    [TestFixture]
    public class SupermarketCheckoutTests
    {
        private readonly SupermarketBasketFactory _basketFactory = new SupermarketBasketFactory();

        /// <summary>
        /// integration test for the checkout
        /// </summary>
        /// <param name="articles">array of market articles</param>
        /// <param name="expectedTotalPrice">expected total price including discount</param>
        [TestCase(new EArticle[] { EArticle.Apple }, 30)]
        [TestCase(new EArticle[] { EArticle.Banana }, 50)]
        [TestCase(new EArticle[] { EArticle.Peach }, 60)]
        [TestCase(new EArticle[] { EArticle.Apple, EArticle.Apple }, 45)]
        [TestCase(new EArticle[] { EArticle.Banana, EArticle.Banana, EArticle.Banana }, 130)]
        [TestCase(new EArticle[] { EArticle.Peach, EArticle.Peach }, 120)]
        [TestCase(new EArticle[] { EArticle.Apple, EArticle.Apple, EArticle.Banana, EArticle.Banana, EArticle.Banana, EArticle.Peach, EArticle.Peach }, 295)]
        public void CreateBill_TestCases_Success(EArticle[] articles, decimal expectedTotalPrice)
        {
            // Arrange
            var basket = _basketFactory.Create(articles);
            var supermarketCheckout = this.CreateSupermarketCheckout();

            // Act
            Bill bill = supermarketCheckout.CreateBill(basket);

            // Assert
            Assert.That(bill.TotalPrice, Is.EqualTo(expectedTotalPrice));
        }

         /// <summary>
         ///  unit test for the calculation
         /// </summary>
         /// <remarks>
         /// the type of an article is not necessary
         /// </remarks>
         /// <param name="numberOfArticels">number of items / articles</param>
         /// <param name="articlePrice">price of an item</param>
         /// <param name="amountOfArticlesForDiscount">number of articles for the discount</param>
         /// <param name="discountPrice">the new price a number of articles</param>
         /// <param name="expectedPrice">the expected total price including discount</param>
        [TestCase(100, 100000, 10, 10, 100)]
        [TestCase(200, 100000, 10, 10, 200)]
        [TestCase(200, 100000, 200, 1, 1)]
        [TestCase(200, 1, 2000, 1, 200)]
        [TestCase(200, 50, 2000, 1, 50 * 200)]
        [TestCase(200, 1000, 2000, 1, 200 * 1000)]
        public void CalculatePrice_TestCases_Success(int numberOfArticels, decimal articlePrice, int amountOfArticlesForDiscount, decimal discountPrice, decimal expectedPrice)
        {
            // Arrange
            var supermarketCheckout = this.CreateSupermarketCheckout();
            var itemDiscount = new ArticleDiscount
            {
                NumberOfItems = (uint) amountOfArticlesForDiscount,
                NewPrice = (uint) discountPrice
            };
            // Act
            decimal price = supermarketCheckout.CalculatePrice((uint)numberOfArticels, articlePrice, itemDiscount);

            // Assert
            Assert.That(price, Is.EqualTo(expectedPrice));
        }

        private SupermarketCheckout CreateSupermarketCheckout()
        {
            return new SupermarketCheckout(new DiscountsRepository(), new PriceRepository());
        }
    }
}
