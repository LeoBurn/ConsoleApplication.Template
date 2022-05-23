using Cornucopias.Mint.Configuration;
using Cornucopias.Mint.Contracts;
using Cornucopias.Mint.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cornucopias.Mint
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            var businessService = host.Services.GetService<IBusinessService>();
            await businessService.MintAsync();

            host.Run();
        }

        /// <summary>
        /// Inject Dependecies and add application.json configuration
        /// </summary>
        /// <param name="args">args from console input</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //Configuration
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            var appconfiguration = config.Get<ApplicationConfiguration>();

            //Create Dependicies
            var hostBuilder = Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        
                        services.AddSingleton(appconfiguration);

                        //services
                        services.AddSingleton<ICaptchaService, CaptchaService>();                        
                        services.AddHttpClient<ICornucopiasService, CornucopiasService>();
                        services.AddSingleton<IBusinessService, BusinessService>();

                        //Logging
                        services.AddLogging();
                        var provider = services.BuildServiceProvider();
                        var factory = provider.GetService<ILoggerFactory>();
                    });
          

            return hostBuilder;
        }
               
    }
}
