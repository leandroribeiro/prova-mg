using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProvaMG.Domain;
using ProvaMG.Domain.DTO;
using ProvaMG.Domain.Entities;
using ProvaMG.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Application
{
    public class AutenticacaoAppService : IAutenticacaoAppService
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppSettings _appSettings;


        public AutenticacaoAppService(AppSettings appSettings, IUsuarioRepository repository)
        {
            _repository = repository;
            _appSettings = appSettings;
        }

        public LoginDTO Login(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return null;
            
            var encontrado = _repository.Obter(email);

            if (encontrado == null)
                return null;

            // TODO substituir por Hash
            if (!encontrado.Password.Equals(senha))
                return null;

            if (!encontrado.IsActive)
                return null;
            
            // authentication successful so generate jwt token
            var token = generateJwtToken(encontrado);

            return new LoginDTO(encontrado, token);

        }

        // helper methods

        private string generateJwtToken(Usuario usuario)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}