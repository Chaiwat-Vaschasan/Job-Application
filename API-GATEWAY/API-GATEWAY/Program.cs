using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;


namespace API_GATEWAY
{
    public class Program
    {
        [System.Obsolete]
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        [System.Obsolete]
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                       .AddEnvironmentVariables();
                    
                })
               
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                    logging.ConfigureNLog($"NLog.{hostingContext.HostingEnvironment.EnvironmentName}.config");
                    
                })
                .UseNLog();
    }
}
