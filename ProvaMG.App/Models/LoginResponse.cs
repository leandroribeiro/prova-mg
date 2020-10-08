namespace ProvaMG.App.Models
{
    public class LoginResponse
    {
        public short Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Token {get;set;}
    }
}