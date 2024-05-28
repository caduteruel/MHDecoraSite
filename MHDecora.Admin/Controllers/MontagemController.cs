using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class MontagemController : Controller
    {
        private readonly IMontagemService _montagemService;

        public MontagemController(IMontagemService montagemService)
        {
            _montagemService = montagemService;
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Montagem montagem, IFormFile arquivo)
        {
            var response = await _montagemService.Salvar(montagem, arquivo);

            if (response)
            {
                Alert("Sucesso!", "A Montagem foi cadastrada.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar esta montagem, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int montagemId)
        {
            bool result = await _montagemService.Excluir(montagemId);

            if (result)
            {
                Alert("Sucesso!", "O Banner foi excluído.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível excluir o banner, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int montagemId)
        {
            var response = await _montagemService.GetById(montagemId);

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
