using ProvaMG.Domain.Entities;

namespace ProvaMG.Domain.DTO
{
    public class LoginDTO
    {
        public LoginDTO(Usuario encontrado, string token)
        {
            this.Id = encontrado.Id;
            this.Email = encontrado.Email;
            this.IsActive = encontrado.IsActive;
            
            this.Token = token;
        }

        public short Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Token {get;set;}
    }
}