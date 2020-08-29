namespace ProvaMG.Application
{
    public interface IAutenticacaoAppService
    {
        bool Login(string email, string senha);
    }
}