using MHDecora.Admin.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoController(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
