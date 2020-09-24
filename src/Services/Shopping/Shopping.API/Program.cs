using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopping.API.Application.CommandHandlers;
using Shopping.API.Data;

namespace Shopping.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ShoppingDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new RouteRegistrarProviderFactory());

        public class RouteRegistrarProviderFactory : IServiceProviderFactory<IServiceCollection>
        {
            public IServiceCollection CreateBuilder(IServiceCollection services)
            {
                return services;
            }

            public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
            {
                var serviceProvider = containerBuilder.BuildServiceProvider();
                var registrar = new RouteRegistrar(new Provider(serviceProvider));
                registrar.RegisterInAssemblyOf(typeof(CartCommandHandler));
                return serviceProvider;
            }
        }

        public class Provider : IServiceProvider
        {
            private readonly ServiceProvider _serviceProvider;
            private readonly IHttpContextAccessor _contextAccessor;

            public Provider(ServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
                _contextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
            }

            public object GetService(Type serviceType)
            {
                return _contextAccessor?.HttpContext?.RequestServices.GetService(serviceType) ??
                       _serviceProvider.GetService(serviceType);
            }
        }
    }
}
