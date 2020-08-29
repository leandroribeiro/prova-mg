using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Internal;
using ProvaMG.Infrasctructure;
using ProvaMG.Infrasctructure.Data;
using Xunit;

namespace ProvaMG.Application.IntegrationTests
{
    public class MunicipioAppServiceTests : BaseAppServiceTests
    {
        private readonly IMunicipioAppService _appService;

        public MunicipioAppServiceTests() : base()
        {
            var repository = new MunicipioRepository(Context);
            _appService = new MunicipioAppService(repository);
        }

        [Fact]
        public void Deve_Retornar_Somente_as_UF()
        {
            var unidadesFederativas = _appService.ObterUnidadesFederativas();
            
            Assert.True(unidadesFederativas!=null);
            Assert.Equal(27, unidadesFederativas.Count);
        }
        
        [Theory]
        [InlineData("MG", 855)]
        [InlineData("SP", 648)]
        [InlineData("RJ", 94)]
        public void Deve_Retornar_Os_Municipios_Por_UF(string unidadeFederativa, int qtdMunicipios)
        {
            var municipios = _appService.ObterMunicipios(unidadeFederativa);
            
            Assert.True(municipios!=null, "Retorno não pode ser nulo");
            Assert.Equal(qtdMunicipios, municipios.Count);
        }
        
        [Theory]
        [InlineData("MG", 855)]
        [InlineData("SP", 648)]
        [InlineData("RJ", 94)]
        public void Deve_Retornar_Os_Municipios_Por_UF_Paginados(string unidadeFederativa, int qtdMunicipios)
        {
            var pagina = 1;
            var municipios = _appService.ObterMunicipiosPaginado(unidadeFederativa, pagina);
            
            Assert.True(municipios!=null, "Retorno não pode ser nulo");
            Assert.Equal(10, municipios.PageSize);
            Assert.Equal(qtdMunicipios, municipios.RowCount);
        }
    }
}