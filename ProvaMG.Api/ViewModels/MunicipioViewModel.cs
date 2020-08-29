using ProvaMG.Domain;

namespace ProvaMG.Api.ViewModels
{
    public class MunicipioViewModel
    {
        public short Id { get; }
        public string Nome { get; }

        public bool Editavel
        {
            get { return (this.Id % 3 == 0); }
        }

        public MunicipioViewModel(Municipio model)
        {
            this.Id = model.Codigo;
            this.Nome = model.Nome;
        }
    }
}