using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProvaMG.Application;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly IMunicipioAppService _appService;

        public UnidadesController(IMunicipioAppService appService)
        {
            _appService = appService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public ActionResult<IList<string>> GetAllSync()
        {
            var unidades = _appService.ObterUnidadesFederativas();

            if (unidades is null)
            {
                return NotFound();
            }

            return new OkObjectResult(unidades);
        }
    }

}