using NSubstitute;
using NUnit.Framework;
using SupermarketCheckout.Services;

namespace SupermarketCheckout.Services.Tests.Services
{
    [TestFixture]
    public class SupermarketBasketFactoryTests
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            var supermarketBasket = this.CreateSupermarketBasket();

            // Act

            // Assert
            Assert.Fail();
        }

        private SupermarketBasketFactory CreateSupermarketBasket()
        {
            return new SupermarketBasketFactory();
        }
    }
}
