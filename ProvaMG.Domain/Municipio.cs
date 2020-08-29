using System;

namespace ProvaMG.Domain
{
    public class Municipio
    {
        public short Codigo { get; set; }
        public string Nome { get; set; }
        public short UFCodigo { get; set; }
        public string MunicipioFazenda { get; set; }
        public bool Ativo { get; set; }
        public string CodigoExt { get; set; }
        public int? RendimentoId { get; set; }
        public string UF { get; set; }

        public bool Editavel
        {
            get
            {
                return DivisivelPorTres(this.Codigo);
            }
        }

        private bool DivisivelPorTres(int numero)
        {
            return (numero % 3 == 0);
        }
    }
}