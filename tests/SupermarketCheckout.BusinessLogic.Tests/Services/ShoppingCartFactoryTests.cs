namespace SupermarketCheckout.BusinessLogic.Tests.Services
{
    using NUnit.Framework;
    using SupermarketCheckout.BusinessLogic.Services;
    using SupermarketCheckout.Common.Models;
    using System;
    using System.Linq;

    /// <summary>
    /// unit tests to create a market basket
    /// </summary>
    [TestFixture]
    public class ShoppingCartFactoryTests
    {
        /// <summary>
        /// tests the creation of a basket 
        /// </summary>
        /// <param name="articles">array of market articles</param>
        [TestCase(new Article[] { Article.Apple })]
        [TestCase(new Article[] { Article.Banana })]
        [TestCase(new Article[] { Article.Peach })]
        [TestCase(new Article[] { Article.Peach, Article.Apple, Article.Peach, Article.Banana })]
        public void Create_TestCases_Success(Article[] articles)
        {
            // Arrange
            var factory = new ShoppingCartFactory();

            // Act
            var supermarketBasket = factory.Create(articles);

            // Assert that the same Articles are in the basket
            CollectionAssert.AreEqual(articles.ToHashSet(), supermarketBasket.MapArticlesToAmount.Keys);

            // Assertion for each item that the amount of articles are counted correctly 
            foreach (var articleObj in Enum.GetValues(typeof(Article)))
            {
                var article = (Article) articleObj;
                int expectedAmount = articles.Where(e => e == article).Count();
                if (supermarketBasket.MapArticlesToAmount.ContainsKey(article))
                    Assert.That(supermarketBasket.MapArticlesToAmount[article], Is.EqualTo(expectedAmount));
            }

        }
    }
}
