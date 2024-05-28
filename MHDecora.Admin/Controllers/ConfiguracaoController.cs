using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class ConfiguracaoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Configurar()
        {
            return View();
        }
    }
}
