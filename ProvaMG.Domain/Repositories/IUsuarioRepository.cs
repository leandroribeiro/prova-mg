using ProvaMG.Domain.Entities;

namespace ProvaMG.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        public Usuario Obter(string email, string senha);
    }
}