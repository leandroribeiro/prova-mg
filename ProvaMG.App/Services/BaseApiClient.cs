using System.Security.Policy;
using Microsoft.Extensions.Configuration;

namespace ProvaMG.App.Services
{
    public abstract class BaseApiClient
    {
        protected string UrlBase { get; }
        
        protected BaseApiClient(IConfiguration configuration)
        {
            this.UrlBase = configuration.GetValue<string>("Api:UrlBase");
        }

    } 
    
}