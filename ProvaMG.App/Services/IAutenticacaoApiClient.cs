using System.Collections.Generic;
using ProvaMG.App.Models;

namespace ProvaMG.App.Services
{
    public interface IAutenticacaoApiClient
    {
        LoginResponse Login(LoginRequest request);
        
    }
}