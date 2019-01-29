using NSubstitute;
using NUnit.Framework;
using SupermarketCheckout.Common.Model;
using System;
using System.Linq;

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

            // Assert that the same Articles are in the basket
            CollectionAssert.AreEqual(articles.ToHashSet(), supermarketBasket.MapArticlesToNumber.Keys);

            // Assert for each item that the number is correct
            foreach (var articleObj in Enum.GetValues(typeof(EArticle)))
            {
                var article = (EArticle) articleObj;
                int expectedAmount = articles.Where(e => e == article).Count();
                if (supermarketBasket.MapArticlesToNumber.ContainsKey(article))
                    Assert.That(supermarketBasket.MapArticlesToNumber[article], Is.EqualTo(expectedAmount));

            }

        }
    }
}
