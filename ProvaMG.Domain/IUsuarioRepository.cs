namespace ProvaMG.Domain
{
    public interface IUsuarioRepository
    {
        public Usuario Obter(string email, string senha);
    }
}