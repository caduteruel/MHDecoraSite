using MHDecora.Admin.Domain.Entities;
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
        public async Task<IActionResult> Categoria()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Tag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarCategoria(Categoria categoria)
        {

            return View();
        }

    }
}
