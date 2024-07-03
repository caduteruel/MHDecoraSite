using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<IActionResult> Index()
        {
            var contato = await _contatoService.GetContato();

            return View(contato.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Contato contato)
        {
            var response = await _contatoService.Editar(contato);

            if (response)
            {
                Alert("Sucesso!", "O Contato foi editado.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível editar o contato, contate a equipe de suporte.", "danger");
            }

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
