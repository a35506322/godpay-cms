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
            // �̷������ܼƥh�]�wappsettings
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            // �]�wSerlLog
            Log.Logger = new LoggerConfiguration()
                        // ���U�Ҧ��]�w�O�i�HŪ�]�w�ɧ�����
                        .ReadFrom.Configuration(configuration)
                        // ���G�O�|�g�X�ԲӸ�T��Deatials https://github.com/RehanSaeed/Serilog.Exceptions
                        .Enrich.FromLogContext()
                        // �s�W�ݩ�
                        //.Enrich.WithProperty("Environment", configuration["Z21Url"])
                        // �̤p��Information��X
                        .MinimumLevel.Information()
                        // �B�zText �˪O�r����
                        // {Properties:j} �۩w�q�ݩ�
                        .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy/MM/dd HH:mm:ss} {Level:u3}] {Properties:j} {Message:lj}{NewLine}{Exception}"
                                        , restrictedToMinimumLevel: LogEventLevel.Information)
                        // �g�i�ɮ�
                        .WriteTo.File(
                            // �]�m�榡��
                            new JsonFormatter(renderMessage: true),
                            // �]�m���|
                            @"logs\log.txt",
                            // �]�m�j�p����
                            rollOnFileSizeLimit: true,
                            // �]�m�ɦW�����
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
