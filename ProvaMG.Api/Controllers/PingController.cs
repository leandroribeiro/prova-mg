using Microsoft.AspNetCore.Mvc;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    public class PingController : ControllerBase
    {
        
        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}