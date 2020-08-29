using System.Linq;
using ProvaMG.Domain;

namespace ProvaMG.Infrasctructure.Data
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository 
    {
        public UsuarioRepository(ProvaMGContext context): base(context)
        {
        }
        public Usuario Obter(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return null;
            
            return this.Context.Usuarios.FirstOrDefault(x => x.Email == email && x.Password == senha);
        }
    }
}