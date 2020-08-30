using System;
using ProvaMG.Domain;
using ProvaMG.Domain.Repositories;

namespace ProvaMG.Application
{
    public class AutenticacaoAppService : IAutenticacaoAppService
    {
        private readonly IUsuarioRepository _repository;

        public AutenticacaoAppService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public bool Login(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return false;
            
            var encontrado = _repository.Obter(email, senha);

            if (encontrado == null || !encontrado.IsActive)
                return false;
            
            return true;
        }
    }
}