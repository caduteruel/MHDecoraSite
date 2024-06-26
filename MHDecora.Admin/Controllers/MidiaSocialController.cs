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

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(MidiaSocial miMidiaSocialdiaSocial)
        {
            var response = await _midiaSocialService.Criar(miMidiaSocialdiaSocial);

            if (response)
            {
                Alert("Sucesso!", "As Mídias Sociais foram cadastradas.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar as mídias sociais, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int midiaSocialId)
        {
            var contato = await _midiaSocialService.GetById(midiaSocialId);

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

        [HttpPost]
        public async Task<IActionResult> Excluir(int midiaSocialId)
        {
            bool result = await _midiaSocialService.Excluir(midiaSocialId);

            if (result)
            {
                Alert("Sucesso!", "As Mídias Sociais foram excluídas.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível excluir as mídias sociais, contate a equipe de suporte.", "danger");
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
