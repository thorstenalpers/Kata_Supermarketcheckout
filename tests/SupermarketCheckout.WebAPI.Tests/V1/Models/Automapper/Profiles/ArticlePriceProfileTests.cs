using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using SupermarketCheckout.BusinessLogic.Models;
using SupermarketCheckout.WebAPI.V1.Models;
using SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles;

namespace SupermarketCheckout.WebAPI.Tests.V1.Models.Automapper.Profiles
{
    [TestFixture]
    public class ArticlePriceProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            ServiceCollection services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            Startup.ConfigureBusinessServices(services, config);

            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

            Mapper.AssertConfigurationIsValid();
        }


        [Test]
        public void Map_ApiModelToDto_Success()
        {
            // Arrange
            var banana = new Article
            {
                Id = 2,
                Name = "Banana"
            };
            var articlePrice = new ArticlePrice
            {
                Article = banana,
                Id = 1,
                UnitPrice = 12
            };

            // Act
            var model = _mapper.Map<ArticlePriceDto>(articlePrice);

            // Assert
            Assert.That(model.Id == articlePrice.Id);
            Assert.That(model.UnitPrice == articlePrice.UnitPrice);
            Assert.That(model.Article.Id == articlePrice.Article.Id);
            Assert.That(model.Article.Name == articlePrice.Article.Name);
        }

        [Test]
        public void Map_DtoToApiModel_Success()
        {
            // Arrange
            var banana = new ArticleDto
            {
                Id = 2,
                Name = "Banana"
            };
            var articlePriceDto = new ArticlePriceDto
            {
                Article = banana,
                Id = 1,
                UnitPrice = 12
            };

            // Act
            var model = _mapper.Map<ArticlePrice>(articlePriceDto);

            // Assert
            Assert.That(model.Id == articlePriceDto.Id);
            Assert.That(model.UnitPrice == articlePriceDto.UnitPrice);
            Assert.That(model.Article.Id == articlePriceDto.Article.Id);
            Assert.That(model.Article.Name == articlePriceDto.Article.Name);
        }
    }
}
