using System.Collections.Generic;
using ProvaMG.Domain.Entities;

namespace ProvaMG.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        public Usuario Obter(string email);

        public Usuario Obter(int id);
        IEnumerable<Usuario> ObterTodos();
    }
}