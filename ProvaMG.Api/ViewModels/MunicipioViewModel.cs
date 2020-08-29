using ProvaMG.Domain;

namespace ProvaMG.Api.ViewModels
{
    public class MunicipioViewModel
    {
        public short Codigo { get; }
        public string Nome { get; }

        public bool Editavel { get; }

        public MunicipioViewModel(Municipio model)
        {
            this.Codigo = model.Codigo;
            this.Nome = model.Nome;
            this.Editavel = DivisivelPorTres(model.Codigo);
        }

        public bool DivisivelPorTres(int numero)
        {
            return (numero % 3 == 0);
        }
    }
}