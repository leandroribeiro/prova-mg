using System.ComponentModel;
using Newtonsoft.Json;

namespace ProvaMG.App.Models
{
    public class MunicipioViewModel
    {
        [DisplayName("Código")]
        [JsonProperty("codigo")]
        public short Codigo { get; private set; }

        [DisplayName("Nome")]
        [JsonProperty("nome")]
        public string Nome { get; private set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; private set; }

        public MunicipioViewModel(short codigo, string nome, bool editavel)
        {
            Codigo = codigo;
            Nome = nome;
            Editavel = editavel;
        }
    }
}