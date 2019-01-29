using NSubstitute;
using NUnit.Framework;
using SupermarketCheckout.Common.Model;

namespace SupermarketCheckout.Services.Tests.Services
{
    [TestFixture]
    public class SupermarketBasketFactoryTests
    {
        [TestCase(new EArticle[] { EArticle.Apple })]
        [TestCase(new EArticle[] { EArticle.Banana })]
        [TestCase(new EArticle[] { EArticle.Peach })]
        [TestCase(new EArticle[] { EArticle.Peach, EArticle.Apple, EArticle.Peach, EArticle.Banana })]
        public void TestMethod1(EArticle[] articles)
        {
            // Arrange
            var factory = new SupermarketBasketFactory();

            // Act
            var supermarketBasket = factory.Create(articles);

            // Assert
            Assert.AreEqual(articles, supermarketBasket.Articles);
        }
    }
}
