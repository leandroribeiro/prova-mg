using System.Collections.Generic;
using System.Linq;
using ProvaMG.Domain;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Application
{
    public class MunicipioAppService : IMunicipioAppService
    {
        private const int PAGE_SIZE = 10;
        
        private readonly IMunicipioRepository _repository;

        public MunicipioAppService(IMunicipioRepository repository)
        {
            _repository = repository;
        }

        public IList<string> ObterUnidadesFederativas()
        {
            return _repository.ObterUnidadesFederativas();
        }

        public IList<Municipio> ObterMunicipios(string unidadeFederativa)
        {
            return _repository.ObterMunicipios(unidadeFederativa).ToList();
        }

        public PagedResult<Municipio> ObterMunicipiosPaginado(int page)
        {
            return _repository.ObterMunicipios().GetPaged(page, PAGE_SIZE);
        }

        public PagedResult<Municipio> ObterMunicipiosPaginado(string unidadeFederativa, int page)
        {
            
            return this.ObterMunicipiosPaginado(unidadeFederativa, page, PAGE_SIZE);
        }

        public PagedResult<Municipio> ObterMunicipiosPaginado(string unidadeFederativa, int page, int pageSize)
        {
            return _repository.ObterMunicipios(unidadeFederativa).GetPaged(page, pageSize);
        }
    }
}