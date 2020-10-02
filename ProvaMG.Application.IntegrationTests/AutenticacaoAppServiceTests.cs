using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaMG.Infrasctructure;
using ProvaMG.Infrasctructure.Data;
using Xunit;

namespace ProvaMG.Application.IntegrationTests
{
    public class AutenticacaoAppServiceTests : BaseAppServiceTests
    {
        private readonly IAutenticacaoAppService _appService;

        public AutenticacaoAppServiceTests() : base()
        {
            var settings = new AppSettings("QUALQUER-COISA");
            var repository = new UsuarioRepository(Context);
            _appService = new AutenticacaoAppService(settings, repository);
        }
        
        [Fact]
        public void Deve_Retornar_Verdadeiro_Quando_Email_e_Senha_Correto_e_Ativo()
        {
            var email = "admin@teste.com.br";
            var senha = "123456";

            var resultado = _appService.Login(email, senha);
            
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado.Token);
        }
        
        [Fact]
        public void Deve_Retornar_Falso_Quando_Email_e_Senha_Correto_e_Ativo()
        {
            var email = "inativo@teste.com.br";
            var senha = "123456";

            var resultado = _appService.Login(email, senha);
            
            Assert.Null(resultado);
        }
        
        [Theory()]
        [InlineData("admin@teste.com.br", "errada")]
        [InlineData("errada@teste.com.br", "123456")]
        public void Deve_Retornar_Falso_Quando_Email_OU_Senha_Incorreto(string email, string senha)
        {
            var resultado = _appService.Login(email, senha);
            
            Assert.Null(resultado);
        }
        
    }
}