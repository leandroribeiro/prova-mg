using System.Collections.Generic;
using ProvaMG.Domain;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Application
{
    public interface IMunicipioAppService
    {
        IList<string> ObterUnidadesFederativas();
        IList<Municipio> ObterMunicipios(string unidadeFederativa);
        PagedResult<Municipio> ObterMunicipiosPaginado(int page);
        PagedResult<Municipio> ObterMunicipiosPaginado(string unidadeFederativa, int page);
        PagedResult<Municipio> ObterMunicipiosPaginado(string unidadeFederativa, int page, int pageSize);
    }
}