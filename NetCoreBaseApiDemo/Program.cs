using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace NetCoreBaseApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
             .WriteTo.File(
                @"LogFiles\Log.txt",
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1),
                rollingInterval: RollingInterval.Day
                )
            .CreateLogger();
            Log.Information("³ÌÐòÆô¶¯");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
