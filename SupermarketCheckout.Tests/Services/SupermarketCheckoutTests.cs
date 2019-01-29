using NSubstitute;
using NUnit.Framework;
using SupermarketCheckout.Model;
using SupermarketCheckout.Services;
using SupermarketCheckout.Services.Model;
using System.Collections;

namespace SupermarketCheckout.Services.Tests.Services
{
    [TestFixture]
    public class SupermarketCheckoutTests
    {
        private readonly SupermarketBasketFactory _basketFactory = new SupermarketBasketFactory();

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

        private SupermarketCheckout CreateSupermarketCheckout()
        {
            return new SupermarketCheckout();
        }

        private SupermarketBasketFactory CreateSupermarketBasket()
        {
            return new SupermarketBasketFactory();
        }
    }
}
