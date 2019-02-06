namespace SupermarketCheckout.API
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.Extensions.PlatformAbstractions;
    using System.IO;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using SupermarketCheckout.API.Swagger;
    using SupermarketCheckout.DataAccess.Repositories;
    using SupermarketCheckout.BusinessLogic.Services;

    /// <summary>
    /// Configuration of the web application
    /// <see href="https://docs.microsoft.com/de-de/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2"> </see>
    /// </summary>
    public class Startup
    {
        readonly IHostingEnvironment _env;
        readonly IConfiguration _config;
        readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// sets the dependencies via IOC
        /// </summary>
        /// <param name="env">WebHosting environment </param>
        /// <param name="config">WebHosting Configuration </param>
        /// <param name="loggerFactory">Logger, configuration via appsettings</param>
        public Startup(IHostingEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // the sample application always uses the latest version, but you may want an explicit version such as Version_2_2
            // note: Endpoint Routing is enabled by default; however, if you need legacy style routing via IRouter, change it to false
            services.AddMvc(options => options.EnableEndpointRouting = true).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            
            ConfigureBusinessServices(services);

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // integrate xml comments
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Defines a class that provides the mechanisms to configure an application's request</param>
        /// <param name="provider">Defines the behavior of a provider that discovers and describes API version information
        /// within an application.</param>
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (_env.IsDevelopment())
            {
                // Development service configuration
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Non-development service configuration
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            // adds Routing Middleware to the request pipeline and configures MVC as the default handler
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            // redirect all HTTP requests to HTTPS
            app.UseHttpsRedirection();
        }

        /// <summary>
        /// Configures all dependencies of business layer services and data access layer repositories
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureBusinessServices(IServiceCollection services)
        {
            // add business services
            services.AddTransient<ISupermarketCheckoutService, SupermarketCheckoutService>();
            services.AddTransient<ISupermarketBasketFactory, SupermarketBasketFactory>();

            // add repositories
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
