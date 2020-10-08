using Newtonsoft.Json;

namespace ProvaMG.App.Models
{
    public class MunicipioRequest
    {
        [JsonProperty("codigo")]
        public readonly short Codigo;
        [JsonProperty("novoNome")]
        public readonly string NovoNome;

        public MunicipioRequest(short codigo, string novoNome)
        {
            Codigo = codigo;
            NovoNome = novoNome;
        }
    }
}