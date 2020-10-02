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
        
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
             var response = _appService.Login(request.Email, request.Senha);

            if (response == null)
                return BadRequest(new { message = "Usuário ou senha está incorreta." });

            return Ok(response);
        }
    }
}