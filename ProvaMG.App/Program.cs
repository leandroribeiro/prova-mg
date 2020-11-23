using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ProvaMG.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Aplicação iniciando...");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Falhou ao iniciar a aplicação");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}