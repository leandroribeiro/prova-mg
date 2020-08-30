using System.Collections.Generic;
using System.Linq;
using ProvaMG.Domain.Entities;

namespace ProvaMG.Domain.Repositories
{
    public interface IMunicipioRepository
    {
        IList<string> ObterUnidadesFederativas();
        IQueryable<Municipio> ObterMunicipios(string unidadeFederativa);
        IQueryable<Municipio> ObterMunicipios();
        int AlterarNome(short codigo, string novoNome);
    }
}