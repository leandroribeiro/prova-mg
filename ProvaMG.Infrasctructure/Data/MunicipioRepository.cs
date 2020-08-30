using System.Collections.Generic;
using System.Linq;
using ProvaMG.Domain;
using ProvaMG.Domain.Entities;
using ProvaMG.Domain.Repositories;

namespace ProvaMG.Infrasctructure.Data
{
    public class MunicipioRepository : BaseRepository, IMunicipioRepository
    {
        public MunicipioRepository(ProvaMGContext context) : base(context)
        {
        }

        public IList<string> ObterUnidadesFederativas()
        {
            return this.Context.Municipios.GroupBy(m => m.UF)
                .Select(x => x.Key)
                .OrderBy(x => x)
                .ToList();
        }

        /// <summary>
        /// /// Somente municípios Ativos ordenados por Nome e filtrado por UF
        /// </summary>
        /// <param name="unidadeFederativa"></param>
        /// <returns></returns>
        public IQueryable<Municipio> ObterMunicipios(string unidadeFederativa)
        {
            return ObterMunicipios()
                .Where(m => m.UF == unidadeFederativa);
        }

        /// <summary>
        /// Somente municípios Ativos ordenados por Nome
        /// </summary>
        /// <returns></returns>
        public IQueryable<Municipio> ObterMunicipios()
        {
            return this.Context.Municipios
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Nome);
        }

        public int AlterarNome(short codigo, string novoNome)
        {
            var item = this.Context.Municipios.Find(codigo);
            item.Nome = novoNome;

            this.Context.Update(item);
            
            return this.Context.SaveChanges();
        }

        public int AlterarNome(Municipio municipio)
        {
            return AlterarNome(municipio.Codigo, municipio.Nome);
        }
    }
}