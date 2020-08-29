using Microsoft.AspNetCore.Mvc;
using ProvaMG.Api.ViewModels;
using ProvaMG.Application;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoAppService _appService;

        public AutenticacaoController(IAutenticacaoAppService appService)
        {
            _appService = appService;
        }
        
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel request)
        {
            var autorizado = _appService.Login(request.Email, request.Senha);

            if (autorizado)
                return Ok();
            
            return Unauthorized();
        }
    }
}