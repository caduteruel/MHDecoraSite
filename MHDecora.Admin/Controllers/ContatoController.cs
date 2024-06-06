using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IOrcamentoService _contatoService;

        public ContatoController(IOrcamentoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<IActionResult> Index()
        {
            var contato = await _contatoService.GetContato();

            return View(contato);
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Contato contato)
        {
            var response = await _contatoService.Criar(contato);

            if (response)
            {
                Alert("Sucesso!", "O Contato foi cadastrado.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar o contato, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var contato = await _contatoService.GetContatoById(id);

            return View(contato);
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

        [HttpPost]
        public async Task<IActionResult> Excluir(int contatoId)
        {
            bool result = await _contatoService.Excluir(contatoId);

            if (result)
            {
                Alert("Sucesso!", "O Contato foi excluído.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível excluir a contato, contate a equipe de suporte.", "danger");
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
