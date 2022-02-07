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
            // �̷������ܼƥh�]�wappsettings
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var sinkInfoOpts = new MSSqlServerSinkOptions();
            // ��ƪ�W��
            sinkInfoOpts.TableName = "CMS_InfoLogs";
            // �C�����J���C��
            sinkInfoOpts.BatchPostingLimit = 5;
            // �C�L�X������LOG
            sinkInfoOpts.BatchPeriod = TimeSpan.FromSeconds(5);
            // �O�_�إ߸�ƪ�
            sinkInfoOpts.AutoCreateSqlTable = true;

            var sinkErrorOpts = new MSSqlServerSinkOptions();
            // ��ƪ�W��
            sinkErrorOpts.TableName = "CMS_ErrorLogs";
            // �C�����J���C��
            sinkErrorOpts.BatchPostingLimit = 5;
            // �C�L�X������LOG
            sinkErrorOpts.BatchPeriod = TimeSpan.FromSeconds(5);
            // �O�_�إ߸�ƪ�
            sinkErrorOpts.AutoCreateSqlTable = true;


            var columnOptions = new ColumnOptions();
            // �R���зǦC
            columnOptions.Store.Remove(StandardColumn.Id);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Properties);

            // �ư��w�g�۩w�q�C�����
            columnOptions.Properties.ExcludeAdditionalProperties = true;
            // �s�W�۩w�q�C�A�|�ۦ�bUseSerilogRequestLogging���o���
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

            // �]�wSerlLog
            Log.Logger = new LoggerConfiguration()                  
                       .MinimumLevel.Debug()
                       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                       .Enrich.FromLogContext()
                       .Enrich.WithExceptionDetails()
                       .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy/MM/dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                        // ���ӿ��~�ŧO����Ƨ�
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
                Log.Error(ex, "�D���N�~�פ�");
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
