using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Assessment.DL;

namespace Assessment.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                   .ConfigureNLog("nlog.config")
                   .GetCurrentClassLogger();
            try
            {
                logger.Info("Initializing application...");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<DBContext>();
                        SeedData.Seed(context);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException, "Application stopped because of an exception.");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //register NLog
                    webBuilder.UseNLog();
                });
    }
}
