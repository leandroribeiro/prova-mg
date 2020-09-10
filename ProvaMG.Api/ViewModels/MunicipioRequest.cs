using System;
using Newtonsoft.Json;

namespace ProvaMG.Api.ViewModels
{
    [Serializable]
    public class MunicipioRequest
    {
        [JsonProperty("codigo")] public short Codigo { get; set; }
        [JsonProperty("novoNome")] public string NovoNome { get; set; }

        public MunicipioRequest()
        {
        }

        public MunicipioRequest(short codigo, string novoNome)
        {
            Codigo = codigo;
            NovoNome = novoNome;
        }
    }
}