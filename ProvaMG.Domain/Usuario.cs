using System;

namespace ProvaMG.Domain
{
    public class Usuario
    {
        public short Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}