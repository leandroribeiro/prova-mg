using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            var unidades = _unidadeApiClient.ObterTodas();

            var indexViewModel = new IndexViewModel()
            {
                Unidades = unidades,
            };

            return View(indexViewModel);
        }

        public MunicipioPageListViewModel ObterMunicipiosPor(string uf, int pagina = 1)
        {
            if (string.IsNullOrWhiteSpace(uf) || uf == "0" || uf == "-1")
                return null;

            return _municipiosApiClient.Obter(uf, pagina);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}