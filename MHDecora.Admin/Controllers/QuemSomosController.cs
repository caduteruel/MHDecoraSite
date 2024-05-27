using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace MHDecora.Admin.Controllers
{
    public class QuemSomosController : Controller
    {
        private readonly IQuemSomosService _quemSomosService;

        public QuemSomosController(IQuemSomosService quemSomosService)
        {
            _quemSomosService = quemSomosService;
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
