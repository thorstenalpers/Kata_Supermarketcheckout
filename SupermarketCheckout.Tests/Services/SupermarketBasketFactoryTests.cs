using NUnit.Framework;
using SupermarketCheckout.Common.Model;
using System;
using System.Linq;

namespace SupermarketCheckout.Services.Tests.Services
{
    /// <summary>
    /// unit tests to create a market basket
    /// </summary>
    [TestFixture]
    public class SupermarketBasketFactoryTests
    {
        /// <summary>
        /// tests the creation of a basket 
        /// </summary>
        /// <param name="articles">array of market articles</param>
        [TestCase(new EArticle[] { EArticle.Apple })]
        [TestCase(new EArticle[] { EArticle.Banana })]
        [TestCase(new EArticle[] { EArticle.Peach })]
        [TestCase(new EArticle[] { EArticle.Peach, EArticle.Apple, EArticle.Peach, EArticle.Banana })]
        public void Create_TestCases_Success(EArticle[] articles)
        {
            // Arrange
            var factory = new SupermarketBasketFactory();

            // Act
            var supermarketBasket = factory.Create(articles);

            // Assert that the same Articles are in the basket
            CollectionAssert.AreEqual(articles.ToHashSet(), supermarketBasket.MapArticlesToNumber.Keys);

            // Assertion for each item that the amount of articles are counted correctly 
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
