using System.Collections.Generic;
using System.Linq;
using ProvaMG.Domain;

namespace ProvaMG.Infrasctructure.Data
{
    public class MunicipioRepository : BaseRepository, IMunicipioRepository
    {
        public MunicipioRepository(ProvaMGContext context): base(context)
        {
        }

        public IList<string> ObterUnidadesFederativas()
        {
            return this.Context.Municipios.GroupBy(m=>m.UF)
                .Select(x => x.Key)
                .OrderBy(x=>x)
                .ToList();
        }

        public IQueryable<Municipio> ObterMunicipios(string unidadeFederativa)
        {
            return ObterMunicipios()
                .Where(m => m.UF == unidadeFederativa);
        }

        public IQueryable<Municipio> ObterMunicipios()
        {
            return this.Context.Municipios
                .OrderBy(x => x.Nome);
        }
    }
}