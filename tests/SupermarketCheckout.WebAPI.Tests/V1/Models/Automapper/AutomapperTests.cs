namespace SupermarketCheckout.WebAPI.Tests.V1.Models.Automapper
{
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles;

    [TestFixture]
    public class AutomapperTests
    {

        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            ServiceCollection services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            Startup.ConfigureBusinessServices(services, config);

            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
