using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging((hostingContext, logging) =>
        {
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
            logging.AddEventSourceLogger();
            // Enable NLog as one of the Logging Provider
            logging.AddNLog();
        })
        .UseStartup<Startup>();
        //public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //      .ConfigureLogging((hostingContext, logging) =>
        //      {
        //          logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //          logging.AddConsole();
        //          logging.AddDebug();
        //          logging.AddEventSourceLogger();
        //          // Enable NLog as one of the Logging Provider
        //          logging.AddNLog();
        //      })
        //    .UseStartup<Startup>();

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
