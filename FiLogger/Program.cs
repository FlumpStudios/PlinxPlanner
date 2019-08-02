using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace PlinxPlanner
{
        /// <summary>
        /// Entry point class
        /// </summary>
        public class Program
        {
            /// <summary>
            /// The entry point main method
            /// </summary>
            /// <param name="args"></param>
            public static void Main(string[] args)
            {
                //const string APP_SETTINGS_NAME = "appsettings.json";

                //var appSettings = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile(APP_SETTINGS_NAME)
                //.Build();

                ////Setup up serilog logging. PM: 15/02/2019
                //var connectionString = appSettings.GetSection("AppSettings:Database:ConnectionString").Value;
                //var SqlTable = appSettings.GetSection("Logging:sqlTable").Value;

                //Log.Logger = new LoggerConfiguration()
                //   .MinimumLevel.Error()            
                //   .Enrich.FromLogContext()
                //   .WriteTo.MSSqlServer(
                //                connectionString,
                //               SqlTable,
                //               autoCreateSqlTable: true)
                //   .CreateLogger();

                try
                {
                    CreateWebHostBuilder(args).Build().Run();
                }
                finally
                {
                    //Log.CloseAndFlush();
                }
            }

        /// <summary>
        /// Build the webhost
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseSerilog()
                    .UseStartup<Startup>();
        }
    }
