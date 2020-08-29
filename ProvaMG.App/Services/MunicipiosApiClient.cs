using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using ProvaMG.App.Controllers;
using ProvaMG.App.Models;

namespace ProvaMG.App.Services
{
    public class MunicipiosApiClient : BaseApiClient, IMunicipiosApiClient
    {
        private readonly HttpClient _httpClient;

        public MunicipiosApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<MunicipioViewModel> Obter(string uf)
        {
            var response = _httpClient.GetAsync($"{UrlBase}{UrlsConfig.ObterMunicipiosPor(uf)}").Result;

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<MunicipioViewModel>>(ordersDraftResponse);
        }
    }
}