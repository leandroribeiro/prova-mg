using ProvaMG.Domain.DTO;

namespace ProvaMG.Application
{
    public interface IAutenticacaoAppService
    {
        LoginDTO Login(string email, string senha);
    }
}