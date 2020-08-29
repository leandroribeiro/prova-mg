using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaMG.Infrasctructure;
using ProvaMG.Infrasctructure.Data;

namespace ProvaMG.Application.IntegrationTests
{
    public abstract class BaseAppServiceTests
    {
        protected ProvaMGContext Context { get; }
        
        public BaseAppServiceTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ProvaMGContext>();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseInternalServiceProvider(serviceProvider);
            
            Context = new ProvaMGContext(builder.Options);
        }
    }
}