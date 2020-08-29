using System.ComponentModel;

namespace ProvaMG.App.Models
{
    public class MunicipioViewModel
    {
        [DisplayName("Id")]

        public short Id { get; private set; }

        [DisplayName("Nome")]

        public string Nome { get; private set; }

        public bool Editavel { get; private set; }

        public MunicipioViewModel(short id, string nome, bool editavel)
        {
            Id = id;
            Nome = nome;
            Editavel = editavel;
        }
    }
}