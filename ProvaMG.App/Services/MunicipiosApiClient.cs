using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using ProvaMG.App.Controllers;
using ProvaMG.App.Models;

namespace ProvaMG.App.Services
{
    public class MunicipiosApiClient : IMunicipiosApiClient
    {
        public IEnumerable<MunicipioViewModel> Obter(string uf)
        {
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync($"http://localhost:5000/municipios/{uf}").Result;

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<MunicipioViewModel>>(ordersDraftResponse);
        }
    }
}