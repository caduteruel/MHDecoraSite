using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Application.Services;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class TemaController : Controller
    {
        private readonly ITagService _tagService;
        private readonly ITemaService _temaService;

        public TemaController(ITemaService temaService, ITagService tagService)
        {
            _temaService = temaService;
            _tagService = tagService;
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

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            var tags = await _tagService.GetTags();

            return View(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Tema tema, IFormFile arquivo, List<string> tag)
        {
            var response = await _temaService.Salvar(tema, arquivo, tag);

            if (response)
            {
                Alert("Sucesso!", "O Tema foi cadastrado.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar este tema, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int temaId)
        {
            bool result = await _temaService.Excluir(temaId);

            if (result)
            {
                Alert("Sucesso!", "O Tema foi excluído.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível excluir o tema, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int temaId)
        {
            var tema = await _temaService.BuscarPorId(temaId);

            return View(tema);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile arquivo, Tema tema)
        {
            var result = await _temaService.Editar(arquivo, tema);

            if (result)
            {
                Alert("Sucesso!", "O Tema foi editado.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível editar o tema, contate a equipe de suporte.", "danger");
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
