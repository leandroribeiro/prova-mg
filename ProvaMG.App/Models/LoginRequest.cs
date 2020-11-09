using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProvaMG.App.Models
{
    public class LoginRequest {
        
        [Required]
        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("senha")]
        public string Senha { get; set; }

        public bool Validate()
        {
            return (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Senha));
        }
    }
}