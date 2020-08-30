using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

            var content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<MunicipioViewModel>>(content);
        }
        
        public MunicipioPageListViewModel Obter(string uf, int pagina)
        {
            var response = _httpClient.GetAsync($"{UrlBase}{UrlsConfig.ObterMunicipiosPorPaginado(uf, pagina)}").Result;

            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<MunicipioPageListViewModel>(content);
        }

        public bool AlterarNome(MunicipioRequest request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = _httpClient.PatchAsync($"{UrlBase}{UrlsConfig.AlterNomeMunicipio(request.Codigo)}", content).Result;

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}