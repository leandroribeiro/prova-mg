using System.ComponentModel;

namespace ProvaMG.App.Models
{
    public class MunicipioViewModel
    {
        [DisplayName("Código")]

        public short Codigo { get; private set; }

        [DisplayName("Nome")]

        public string Nome { get; private set; }

        public bool Editavel { get; private set; }

        public MunicipioViewModel(short codigo, string nome, bool editavel)
        {
            Codigo = codigo;
            Nome = nome;
            Editavel = editavel;
        }
    }
}