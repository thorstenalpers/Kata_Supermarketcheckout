namespace SupermarketCheckout.BusinessLogic.Tests.Services
{
    using AutoMapper;
    using NSubstitute;
    using NUnit.Framework;
    using SupermarketCheckout.BusinessLogic.Services;
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories;

    [TestFixture]
    public class SupermarketCheckoutServiceTests
    {
        IDiscountRepository _subDiscountRepository;
        IPriceRepository _subPriceRepository;
        IArticleRepository _subArticleRepository;
        IMapper _mapper;

        [OneTimeSetUp]
        public void SetUp()
        {
            _subDiscountRepository = Substitute.For<IDiscountRepository>();
            _subPriceRepository = Substitute.For<IPriceRepository>();
            _subArticleRepository = Substitute.For<IArticleRepository>();
            _mapper = Substitute.For<IMapper>();
        }

        SupermarketCheckoutService CreateService()
        {
            return new SupermarketCheckoutService(
                _subDiscountRepository,
                _subPriceRepository, 
                _subArticleRepository,
                _mapper);
        }

        /// <summary>
        ///  unit test for the calculation
        /// </summary>
        /// <remarks>
        /// the type of an article is not necessary
        /// </remarks>
        /// <param name="numberOfArticels">number of articles</param>
        /// <param name="articlePrice">price of an article</param>
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
            var supermarketCheckout = new SupermarketCheckoutService(_subDiscountRepository, _subPriceRepository, _subArticleRepository, _mapper);
            var itemDiscount = new ArticleDiscount
            {
                NumberOfArticles = amountOfArticlesForDiscount,
                NewPrice = discountPrice
            };
            // Act
            decimal price = supermarketCheckout.CalculatePrice(numberOfArticels, articlePrice, itemDiscount);

            // Assert
            Assert.That(price, Is.EqualTo(expectedPrice));
        }
    }
}
