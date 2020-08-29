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
        
        public MunicipioPageListViewModel Obter(string uf, int pagina)
        {
            var response = _httpClient.GetAsync($"{UrlBase}{UrlsConfig.ObterMunicipiosPorPaginado(uf, pagina)}").Result;

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<MunicipioPageListViewModel>(ordersDraftResponse);
        }
    }

    public class MunicipioPageListViewModel
    {
        [JsonProperty("results")]
        public IList<MunicipioViewModel> Results { get; set; }
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("rowCount")]
        public int RowCount { get; set; }
        [JsonProperty("firstRowOnPage")]
        public int FirstRowOnPage { get; set; }
        [JsonProperty("lastRowOnPage")]
        public int LastRowOnPage { get; set; }
    }
}