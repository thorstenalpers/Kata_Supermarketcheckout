namespace SupermarketCheckout.BusinessLogic.Tests.Services
{
    using NSubstitute;
    using NUnit.Framework;
    using SupermarketCheckout.BusinessLogic.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using SupermarketCheckout.Common.Models;
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories;

    [TestFixture]
    public class SupermarketCheckoutServiceTests
    {
        IDiscountRepository _subDiscountRepository;
        IPriceRepository _subPriceRepository;

        [SetUp]
        public void SetUp()
        {
            _subDiscountRepository = Substitute.For<IDiscountRepository>();
            _subPriceRepository = Substitute.For<IPriceRepository>();
        }

        SupermarketCheckoutService CreateService()
        {
            return new SupermarketCheckoutService(
                _subDiscountRepository,
                _subPriceRepository);
        }

        /// <summary>
        /// unit test for the checkout
        /// </summary>
        [Test]
        public void CreateBill_EmptyBasket_Ok()
        {
            // Arrange
            var service = CreateService();

            // Act
            Bill bill = service.CreateBill(new Basket());

            // Assert
            _subDiscountRepository.Received().GetDiscountList();
            _subPriceRepository.Received().GetPriceList();
            Assert.That(bill.TotalPrice, Is.EqualTo((decimal)0));
        }

        /// <summary>
        /// unit test for the checkout
        /// </summary>
        [Test]
        public void CreateBill_BasketIsNull_Ok()
        {
            // Arrange
            var service = CreateService();

            // Act
            Bill bill = service.CreateBill(null);

            // Assert
            _subDiscountRepository.Received().GetDiscountList();
            _subPriceRepository.Received().GetPriceList();
            Assert.That(bill.TotalPrice, Is.EqualTo((decimal) 0));
        }

        /// <summary>
        ///  integration test for the calculation
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
            var supermarketCheckout = new SupermarketCheckoutService(new DiscountRepository(), new PriceRepository());
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
    }
}
