using System.Collections.Generic;
using System.Linq;
using ProvaMG.Domain;
using ProvaMG.Domain.Entities;
using ProvaMG.Domain.Repositories;

namespace ProvaMG.Infrasctructure.Data
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository 
    {
        public UsuarioRepository(ProvaMGContext context): base(context)
        {
        }
        public Usuario Obter(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;
            
            return this.Context.Usuarios.FirstOrDefault(x => x.Email == email);
        }

        public Usuario Obter(int id)
        {
            if (id <= 0)
                return null;
            
            return this.Context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return this.Context.Usuarios.ToList();
        }
    }
}