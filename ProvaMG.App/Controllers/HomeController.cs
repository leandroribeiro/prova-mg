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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var unidades = new UnidadeFederativaApiClient().ObterTodas();

            var indexViewModel = new IndexViewModel()
            {
                Unidades = unidades,
            };

            return View(indexViewModel);
        }

        public IEnumerable<MunicipioViewModel> ObterMunicipiosPor(string uf)
        {
            if (string.IsNullOrWhiteSpace(uf) || uf == "0" || uf == "-1")
                return null;

            return new MunicipiosApiClient().Obter(uf);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}