using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 依照環境變數去設定appsettings
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            // 設定SerlLog
            Log.Logger = new LoggerConfiguration()
                        // 底下所有設定是可以讀設定檔完成的
                        .ReadFrom.Configuration(configuration)
                        // 似乎是會寫出詳細資訊的Deatials https://github.com/RehanSaeed/Serilog.Exceptions
                        .Enrich.FromLogContext()
                        // 新增屬性
                        //.Enrich.WithProperty("Environment", configuration["Z21Url"])
                        // 最小為Information輸出
                        .MinimumLevel.Information()
                        // 處理Text 樣板字面值
                        // {Properties:j} 自定義屬性
                        .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy/MM/dd HH:mm:ss} {Level:u3}] {Properties:j} {Message:lj}{NewLine}{Exception}"
                                        , restrictedToMinimumLevel: LogEventLevel.Information)
                        // 寫進檔案
                        .WriteTo.File(
                            // 設置格式化
                            new JsonFormatter(renderMessage: true),
                            // 設置路徑
                            @"logs\log.txt",
                            // 設置大小限制
                            rollOnFileSizeLimit: true,
                            // 設置檔名有日期
                            rollingInterval: RollingInterval.Day)
                        .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
