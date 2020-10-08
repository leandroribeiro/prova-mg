using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProvaMG.App.Models;
using ProvaMG.App.Services;

namespace ProvaMG.App.Controllers
{
    public class ContaController : Controller
    {
        private readonly IAutenticacaoApiClient _autenticacaoService;

        public ContaController(IAutenticacaoApiClient autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var request = new LoginRequest(){
                Email = email, 
                Senha = senha
                };
            
            var response = _autenticacaoService.Login(request);

             if (response == null)
             {
                 ModelState.AddModelError("", "Usuário ou senha inválido");
                 return View();
             }
    
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, response.Email));
            identity.AddClaim(new Claim(ClaimTypes.Email, response.Email));
            identity.AddClaim(new Claim(ClaimTypes.Sid, response.Id.ToString()));
    
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Logout()
        {
             await HttpContext.SignOutAsync();
             
            return Redirect("/");
        }
    }
}