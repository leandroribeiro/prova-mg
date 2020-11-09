using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProvaMG.App.Models;

namespace ProvaMG.App.Services
{
    public class AutenticacaoApiClient : BaseApiClient, IAutenticacaoApiClient
    {
        private readonly HttpClient _httpClient;
        
        public AutenticacaoApiClient(IConfiguration configuration, HttpClient httpClient) : base(configuration)
        {
            _httpClient = httpClient;
        }

        public LoginResponse Login(LoginRequest request)
        {
            if (request.Validate())
            {
                var jsonRequest = JsonConvert.SerializeObject(request);

                var contentRequest = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync($"{UrlBase}{UrlsConfig.Autenticar}", contentRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<LoginResponse>(contentResponse);
                }
            }

            return null;
        }
    }
}