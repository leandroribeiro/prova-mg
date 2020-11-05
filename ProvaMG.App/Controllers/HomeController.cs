using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaMG.App.Models;
using ProvaMG.App.Services;

namespace ProvaMG.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnidadeFederativaApiClient _unidadeApiClient;
        private readonly IMunicipiosApiClient _municipiosApiClient;

        public HomeController(IUnidadeFederativaApiClient unidadeApiClient, IMunicipiosApiClient municipiosApiClient)
        {
            _unidadeApiClient = unidadeApiClient;
            _municipiosApiClient = municipiosApiClient;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ObterUnidades()
        {

            var unidades = _unidadeApiClient.ObterTodas();
            
            return new OkObjectResult(unidades);
        }
        
        [Authorize]
        public IActionResult ObterMunicipiosPor(string uf, int pagina = 1)
        {
            if (string.IsNullOrWhiteSpace(uf) || uf == "0" || uf == "-1")
                return BadRequest();

            var municipios = _municipiosApiClient.Obter(uf, pagina);
            
            return new OkObjectResult(municipios);
        }

        [Authorize]
        public IActionResult AlterarNomeMunicipio(short codigo, string novoNome)
        {
            if (codigo <= 0 || string.IsNullOrWhiteSpace(novoNome))
                return BadRequest();

            _municipiosApiClient.AlterarNome(new MunicipioRequest(codigo, novoNome));
            
            return Ok();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}