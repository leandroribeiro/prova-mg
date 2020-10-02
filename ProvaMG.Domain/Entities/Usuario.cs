using System.Text.Json.Serialization;

namespace ProvaMG.Domain.Entities
{
    public class Usuario
    {
        public short Id { get; set; }
        
        public string Email { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
        
        public bool IsActive { get; set; }
    }
}