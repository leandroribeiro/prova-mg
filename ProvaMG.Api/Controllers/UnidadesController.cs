using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProvaMG.Application;
using ProvaMG.Domain;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly IMunicipioRepository _repository;

        public UnidadesController(IMunicipioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public ActionResult<IList<string>> GetAllSync()
        {
            var unidades = _repository.ObterUnidadesFederativas();

            if (unidades is null)
            {
                return NotFound();
            }

            return new OkObjectResult(unidades);
        }
    }

}