namespace SupermarketCheckout.API.Tests.V1.Controllers
{
    using CoreAPI1.API.V1.Controllers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using SupermarketCheckout.API.V1.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;

    [TestFixture]
    public class SupermarketCheckoutControllerTests
    {
        SupermarketCheckoutController _controller;

        [OneTimeSetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();

            Startup.ConfigureBusinessServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var supermarketCheckoutService = serviceProvider.GetRequiredService<ISupermarketCheckoutService>();
            var supermarketBasketFactory = serviceProvider.GetRequiredService<ISupermarketBasketFactory>();

            _controller = new SupermarketCheckoutController(supermarketCheckoutService, supermarketBasketFactory);
        }

        [TestCaseSource("TestCaseData")]
        public void CalculatePrice_TestCases_Ok(ShoppingCart shoppingCart, decimal expectedTotalPrice)
        {
            // Act + Arrange
            ActionResult<Bill> response = _controller.CreateBill(shoppingCart) as ActionResult<Bill>;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response.Result);
            var okObjectResult = response.Result as OkObjectResult;
            Assert.That(okObjectResult.StatusCode == 200);

            Assert.IsInstanceOf<Bill>(okObjectResult.Value);
            var billResponse = okObjectResult.Value as Bill;
            Assert.That(billResponse.TotalPrice == expectedTotalPrice);
        }

        public void CalculatePrice_InvalidBasket_StatusCode500()
        {
            // Act + Arrange
            ActionResult<Bill> response = null;// _controller.CreateBill(new ShoppingCart()) as ActionResult<Bill>;

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(response.Result);
            var okObjectResult = response.Result as StatusCodeResult;
            Assert.That(okObjectResult.StatusCode == StatusCodes.Status400BadRequest);
        }

        public static IEnumerable<object[]> TestCaseData()
        {
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Apple } }, (decimal) 30 };
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Banana } }, (decimal) 50 };
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Peach } }, (decimal) 60 };
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Apple, EArticle.Apple } }, (decimal) 45 };
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Banana, EArticle.Banana, EArticle.Banana } }, (decimal) 130 };
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Peach, EArticle.Peach } }, (decimal) 120 };
            yield return new object[] { new ShoppingCart { Items = new EArticle[] { EArticle.Apple, EArticle.Apple, EArticle.Banana, EArticle.Banana, EArticle.Banana, EArticle.Peach, EArticle.Peach } }, (decimal) 295 };
        }
    }
}
