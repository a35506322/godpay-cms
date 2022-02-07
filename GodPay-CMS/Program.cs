using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using Serilog.Exceptions;

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

            var sinkInfoOpts = new MSSqlServerSinkOptions();
            // 資料表名稱
            sinkInfoOpts.TableName = "CMS_InfoLogs";
            // 每次插入的列數
            sinkInfoOpts.BatchPostingLimit = 5;
            // 每過幾秒釋放LOG
            sinkInfoOpts.BatchPeriod = TimeSpan.FromSeconds(5);
            // 是否建立資料表
            sinkInfoOpts.AutoCreateSqlTable = true;

            var sinkErrorOpts = new MSSqlServerSinkOptions();
            // 資料表名稱
            sinkErrorOpts.TableName = "CMS_ErrorLogs";
            // 每次插入的列數
            sinkErrorOpts.BatchPostingLimit = 5;
            // 每過幾秒釋放LOG
            sinkErrorOpts.BatchPeriod = TimeSpan.FromSeconds(5);
            // 是否建立資料表
            sinkErrorOpts.AutoCreateSqlTable = true;


            var columnOptions = new ColumnOptions();
            // 刪除標準列
            columnOptions.Store.Remove(StandardColumn.Id);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Properties);

            // 排除已經自定義列的資料
            columnOptions.Properties.ExcludeAdditionalProperties = true;
            // 新增自定義列，會自行在UseSerilogRequestLogging取得資料
            columnOptions.AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn {  ColumnName = "Account", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "RequestMethod", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "EndpointName", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "RequestPath", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "QueryString", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "RequestHeader", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "Host", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "Protocol", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "Scheme", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "RequestBody", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "ContentType", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "ResponseBody", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "StatusCode", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "Code", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "Message", DataType =SqlDbType.VarChar, },
                new SqlColumn {  ColumnName = "Data", DataType =SqlDbType.VarChar, },
            };

            IDecipherHelper decipher = new DecipherHelper();

            // 設定SerlLog
            Log.Logger = new LoggerConfiguration()                  
                       .MinimumLevel.Debug()
                       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                       .Enrich.FromLogContext()
                       .Enrich.WithExceptionDetails()
                       .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy/MM/dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                        // 按照錯誤級別分資料夾
                       .WriteTo.Map(
                        evt => evt.Level, 
                       (level, wt) => wt.File(
                           new CompactJsonFormatter(), 
                           path: @$"logs\{level}\{level}.log", 
                           restrictedToMinimumLevel: LogEventLevel.Information, 
                           rollOnFileSizeLimit: true, 
                           rollingInterval: RollingInterval.Day))
                       .WriteTo.Map(
                        evt => evt.Level,
                       (level, wt) => wt.MSSqlServer(
                          connectionString: decipher.ConnDecryptorAES(configuration.GetSection("SettingConfig:ConnectionSettings:IPASS").Value),
                          sinkOptions: level== LogEventLevel.Error ? sinkErrorOpts:sinkInfoOpts,
                          columnOptions: columnOptions,
                          restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information))
                        .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "主機意外終止");
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
