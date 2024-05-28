using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class TemaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _montagemService.Buscar();

            if (response == null)
            {
                Alert("Erro!", "Não foi possível carregar os dados, contate a equipe de suporte.", "danger");

                return View(response);
            }

            return View(response);
        }
    }
}
