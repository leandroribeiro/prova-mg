using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProvaMG.Api.ViewModels;
using ProvaMG.Application;
using ProvaMG.Domain;
using ProvaMG.Domain.Repositories;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private const int PAGE_SIZE = 10;

        private readonly IMunicipioRepository _repository;

        public MunicipiosController(IMunicipioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<MunicipioViewModel>), (int) HttpStatusCode.OK)]
        public ActionResult<IList<MunicipioViewModel>> GetAllSync()
        {
            var municipios = _repository
                .ObterMunicipios()
                .Select(x => new MunicipioViewModel(x))
                .ToList();

            return municipios;
        }

        [HttpPatch("{codigo:int}")]
        [ProducesResponseType(typeof(IActionResult), (int) HttpStatusCode.OK)]
        public IActionResult AlterarNome([FromRoute] int codigo, [FromBody] MunicipioRequest request)
        {
            var afetados = _repository.AlterarNome(request.Codigo, request.NovoNome);

            if (afetados <= 0)
                return StatusCode((int) HttpStatusCode.InternalServerError);

            return Ok();
        }

        [HttpGet("{uf}")]
        [ProducesResponseType(typeof(List<MunicipioViewModel>), (int) HttpStatusCode.OK)]
        public ActionResult<List<MunicipioViewModel>> GetAllSync(string uf)
        {
            var municipios = _repository
                .ObterMunicipios(uf)
                .Select(x => new MunicipioViewModel(x))
                .ToList();

            return new OkObjectResult(municipios);
        }

        [HttpGet("{uf}/{page:int}")]
        [ProducesResponseType(typeof(List<MunicipioViewModel>), (int) HttpStatusCode.OK)]
        public ActionResult<PagedResult<MunicipioViewModel>> GetAllSync(string uf, int page)
        {
            var municipios = _repository.ObterMunicipios(uf)
                .Select(x => new MunicipioViewModel(x))
                .GetPaged(page, PAGE_SIZE);

            return municipios;
        }
    }
}