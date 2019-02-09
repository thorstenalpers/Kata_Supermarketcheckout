namespace SupermarketCheckout.WebAPI.Tests.V1.Controllers
{
    using SupermarketCheckout.WebAPI.V1.Controllers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using SupermarketCheckout.WebAPI.V1.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

    [TestFixture]
    public class SupermarketCheckoutControllerTests
    {
        SupermarketCheckoutController _controller;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            Startup.ConfigureBusinessServices(services, config);

            var serviceProvider = services.BuildServiceProvider();
            var supermarketCheckoutService = serviceProvider.GetRequiredService<ISupermarketCheckoutService>();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            _controller = new SupermarketCheckoutController(supermarketCheckoutService, mapper);
        }

        [TestCaseSource("TestCaseData")]
        public void CalculatePrice_TestCases_Ok(ShoppingBasket ShoppingBasket, decimal expectedTotalPrice)
        {
            // Act + Arrange
            Task<ActionResult<Bill>> task = _controller.Index(ShoppingBasket) as Task<ActionResult<Bill>>;
            var ok = task.Wait(TimeSpan.FromSeconds(10));
            Assert.That(ok == true);
            ActionResult<Bill> response = task.Result;

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
            ActionResult<Bill> response = null;// _controller.CreateBill(new ShoppingBasket()) as ActionResult<Bill>;

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(response.Result);
            var okObjectResult = response.Result as StatusCodeResult;
            Assert.That(okObjectResult.StatusCode == StatusCodes.Status400BadRequest);
        }

        public static IEnumerable<object[]> TestCaseData()
        {
            var apple = new Article
            {
                Id = 1,
                Name = "Apple"
            };
            var banana = new Article
            {
                Id = 2,
                Name = "Banana"
            };
            var peach = new Article
            {
                Id = 3,
                Name = "Peach"
            };

            yield return new object[] {
                new ShoppingBasket {
                    Articles = new BasketItem[]
                    {
                        new BasketItem
                        {
                            Article = banana,
                            ArticleDiscount = new ArticleDiscount
                            {
                                Article = banana,
                                Id = 1,
                                NewPrice = 130,
                                NumberOfArticles = 3
                            },
                            NumberOfArticles = 1,
                            ArticlePrice = new ArticlePrice
                            {
                                Id = 1,
                                Article = banana,
                                UnitPrice = 50
                            }
                        }
                    }
                } ,  (decimal) 50 };
        }
    }
}
