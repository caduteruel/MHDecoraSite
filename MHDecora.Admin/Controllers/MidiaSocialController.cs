using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    [Authorize]
    public class MidiaSocialController : Controller
    {
        private readonly IMidiaSocialService _midiaSocialService;

        public MidiaSocialController(IMidiaSocialService midiaSocialService)
        {
            _midiaSocialService = midiaSocialService;
        }

        public async Task<IActionResult> Index()
        {
            var contato = await _midiaSocialService.Consultar();

            return View(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(MidiaSocial midiaSocial)
        {
            var response = await _midiaSocialService.Editar(midiaSocial);

            if (response)
            {
                Alert("Sucesso!", "As Mídias Sociais foram editados.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível editar as mídias sociais, contate a equipe de suporte.", "danger");
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
