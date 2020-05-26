using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace Shop.Web
{
    public class Program
    {
        public static IConfiguration appConfiguration { get; } = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
         .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
         .AddEnvironmentVariables()
         .Build();
        public static int Main(string[] args)
        {
            ConfigureLogging();

            try
            {
                Log.Logger.Information("starting application...");

                CreateHostBuilder(args).Build().Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "application terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(appConfiguration);
                }).UseSerilog();

        private static void ConfigureLogging()
        {
            var EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var Dir = Directory.GetCurrentDirectory();
            var LogFile = string.Empty;
            var connString = appConfiguration.GetSection("ConfigSetting:ConnectionStrings")["DbConnectionString"];
            var tableName = "AppLog";
            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Add(StandardColumn.LogEvent);
            columnOptions.TimeStamp.DataType = SqlDbType.DateTimeOffset;
            LogFile = Dir + "\\Logs\\AppLog.txt";

            Log.Logger = new LoggerConfiguration()
                     .MinimumLevel.Debug()
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                     .MinimumLevel.Override("System", LogEventLevel.Warning)
                     .Enrich.FromLogContext()
                     .WriteTo.File(LogFile, rollingInterval: RollingInterval.Day)
                     .WriteTo.MSSqlServer(
                        connectionString: connString,
                        sinkOptions: new SinkOptions
                        {
                            TableName = tableName,
                            AutoCreateSqlTable = true,
                            SchemaName = "dbo"
                        },
                        columnOptions: columnOptions,
                        restrictedToMinimumLevel: LogEventLevel.Debug)
                        .CreateLogger();
        }
    }
}
