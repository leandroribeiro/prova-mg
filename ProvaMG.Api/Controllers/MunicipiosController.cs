using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProvaMG.Api.ViewModels;
using ProvaMG.Application;
using ProvaMG.Domain;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioAppService _appService;

        public MunicipiosController(IMunicipioAppService appService)
        {
            _appService = appService;
        }
        
        [HttpGet()]
        [ProducesResponseType(typeof(List<MunicipioViewModel>), (int)HttpStatusCode.OK)]
        public ActionResult<PagedResult<Municipio>> GetAllSync()
        {
            var municipios = _appService.ObterMunicipiosPaginado(1);

            if (municipios is null)
            {
                return NotFound();
            }

            return municipios;
        }
        
        [HttpGet("{uf}")]
        [ProducesResponseType(typeof(List<MunicipioViewModel>), (int)HttpStatusCode.OK)]
        public ActionResult<List<MunicipioViewModel>> GetAllSync(string uf)
        {
            var municipios = _appService.ObterMunicipios(uf);

            if (municipios is null)
            {
                return NotFound();
            }

            return municipios.Select(x=>new MunicipioViewModel(x)).ToList();
        }
        
        [HttpGet("{uf}/{page:int}")]
        [ProducesResponseType(typeof(List<MunicipioViewModel>), (int)HttpStatusCode.OK)]
        public ActionResult<PagedResult<Municipio>> GetAllSync(string uf, int page)
        {
            var municipios = _appService.ObterMunicipiosPaginado(uf, page);

            if (municipios is null)
            {
                return NotFound();
            }

            return municipios;
        }
    }
}