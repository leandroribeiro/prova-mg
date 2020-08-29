using Microsoft.AspNetCore.Mvc;

namespace ProvaMG.App.Controllers
{
    public class TemplateController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Forms()
        {
            return View();
        }
        
        public IActionResult Tables()
        {
            return View();
        }
        
        public IActionResult Counters()
        {
            return View();
        }
        
    }
}