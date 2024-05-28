using MHDecora.Admin.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class TemaController : Controller
    {
        private readonly ITemaService _temaService;

        public TemaController(ITemaService temaService)
        {
            _temaService = temaService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _temaService.Buscar();

            if (response == null)
            {
                Alert("Erro!", "Não foi possível carregar os dados, contate a equipe de suporte.", "danger");

                return View(response);
            }

            return View(response);
        }

        private void Alert(string titulo, string mensagem, string alerta)
        {
            TempData["Titulo"] = titulo;
            TempData["Mensagem"] = mensagem;
            TempData["TipoAlerta"] = alerta;
        }
    }
}
