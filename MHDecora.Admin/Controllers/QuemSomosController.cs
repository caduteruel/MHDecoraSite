using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class QuemSomosController : Controller
    {
        private readonly IQuemSomosService _quemSomosService;

        public QuemSomosController(IQuemSomosService quemSomosService)
        {
            _quemSomosService = quemSomosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile imagem, QuemSomos dados)
        {
            var result = await _quemSomosService.Editar(dados, imagem);

            if (result)
            {
                Alert("Sucesso!", "A Seção Quem Somos foi editada.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível editar a seção, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(QuemSomos dados, IFormFile imagem)
        {
            await _quemSomosService.Salvar(dados, imagem);

            Alert("Sucesso!", "Seção Quem Somos foi atualizada.", "success");

            return RedirectToAction("Index");
        }

        private void Alert(string titulo, string mensagem, string alerta)
        {
            TempData["Titulo"] = titulo;
            TempData["Mensagem"] = mensagem;
            TempData["TipoAlerta"] = alerta;
        }
    }
}
