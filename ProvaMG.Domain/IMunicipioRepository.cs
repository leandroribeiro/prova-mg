using System.Collections.Generic;
using System.Linq;

namespace ProvaMG.Domain
{
    public interface IMunicipioRepository
    {
        IList<string> ObterUnidadesFederativas();
        IQueryable<Municipio> ObterMunicipios(string unidadeFederativa);
        IQueryable<Municipio> ObterMunicipios();
    }
}