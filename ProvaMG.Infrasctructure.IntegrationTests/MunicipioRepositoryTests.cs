using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaMG.Infrasctructure.Data;
using Xunit;

namespace ProvaMG.Infrasctructure.IntegrationTests
{
    public class MunicipioRepositoryTests
    {
        private MunicipioRepository _repository;

        public MunicipioRepositoryTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ProvaMGContext>();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseInternalServiceProvider(serviceProvider);
            
            var context = new ProvaMGContext(builder.Options);
            
            _repository = new MunicipioRepository(context);
        }
        [Fact]
        public void Deve_Retornar_Somente_as_UF()
        {
            var unidadesFederativas = _repository.ObterUnidadesFederativas();
            
            Assert.True(unidadesFederativas!=null);
            Assert.Equal(27, unidadesFederativas.Count);
        }
        
        [Theory]
        [InlineData("MG", 854)]
        [InlineData("SP", 647)]
        [InlineData("RJ", 94)]
        public void Deve_Retornar_Os_Municipios_Por_UF(string unidadeFederativa, int qtdMunicipios)
        {
            var municipios = _repository.ObterMunicipios(unidadeFederativa);
            
            Assert.True(municipios!=null, "Retorno não pode ser nulo");
            Assert.Equal(qtdMunicipios, municipios.Count());
        }
        
        [Theory]
        [InlineData("MG", 854)]
        [InlineData("SP", 647)]
        [InlineData("RJ", 94)]
        public void Deve_Retornar_Os_Municipios_Por_UF_Paginados(string unidadeFederativa, int qtdMunicipios)
        {
            var pagina = 1;
            var municipios = _repository.ObterMunicipios(unidadeFederativa).GetPaged(pagina, 10);
            
            Assert.True(municipios!=null, "Retorno não pode ser nulo");
            Assert.Equal(10, municipios.PageSize);
            Assert.Equal(qtdMunicipios, municipios.RowCount);
        }
        
        [Theory]
        [InlineData("MG")]
        [InlineData("SP")]
        [InlineData("RJ")]
        public void Deve_Retornar_Os_Municipios_Por_UF_Divisiveis_Por_Tres(string unidadeFederativa)
        {
            var municipios = _repository.ObterMunicipios(unidadeFederativa).Where(x=>x.Codigo % 3 == 0).ToList();
            
            Assert.True(municipios!=null, "Retorno não pode ser nulo");
            Assert.True(municipios.Count>0);
        }
    }
}