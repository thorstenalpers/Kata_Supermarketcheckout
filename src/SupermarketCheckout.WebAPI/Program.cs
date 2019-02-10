namespace SupermarketCheckout.WebAPI
{
    using DataAccess;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;

    /// <summary>
    /// Application entry point of the SupermarketCheckout
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Creates and starts the web application
        /// </summary>
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<SupermarketCheckoutContext>();
                    context.Database.Migrate();

                    SupermarketCheckoutInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        /// <summary>
        /// Creates the IWebHostBuilder
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
