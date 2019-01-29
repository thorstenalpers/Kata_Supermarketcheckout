using NSubstitute;
using NUnit.Framework;
using SupermarketCheckout.Services;

namespace SupermarketCheckout.Services.Tests.Services
{
    [TestFixture]
    public class SupermarketCheckoutTests
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            var supermarketCheckout = this.CreateSupermarketCheckout();
            var supermarketBasket = this.CreateSupermarketBasket();

            // Act

            // Assert
            Assert.Fail();
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
