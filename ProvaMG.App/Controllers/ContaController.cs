using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProvaMG.App.Models;
using ProvaMG.App.Services;

namespace ProvaMG.App.Controllers
{
    public class ContaController : Controller
    {
        private readonly ILogger<ContaController> _logger;
        private readonly IAutenticacaoApiClient _autenticacaoService;

        public ContaController(ILogger<ContaController> logger, IAutenticacaoApiClient autenticacaoService)
        {
            _logger = logger;
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
            var request = new LoginRequest()
            {
                Email = email,
                Senha = senha
            };

            try
            {
                var response = _autenticacaoService.Login(request);

                if (response == null)
                {
                    _logger.LogInformation("Usuário ou senha inválido");
                    
                    ModelState.AddModelError("", "Usuário ou senha inválido");
                    return View();
                }

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, response.Email));
                identity.AddClaim(new Claim(ClaimTypes.Email, response.Email));
                identity.AddClaim(new Claim(ClaimTypes.Sid, response.Id.ToString()));

                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Falha ao tentar logar");
                
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}