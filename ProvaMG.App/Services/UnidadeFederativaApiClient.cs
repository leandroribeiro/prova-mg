using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProvaMG.App.Services
{
    public class UnidadeFederativaApiClient : IUnidadeFederativaApiClient
    {
        public IEnumerable<string> ObterTodas()
        {
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync("http://localhost:5000/unidades").Result;

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<string>>(ordersDraftResponse);
        }
    }
}