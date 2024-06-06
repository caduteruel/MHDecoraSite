using Azure;
using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetTags();

            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Tag tag)
        {
            var response = await _tagService.Criar(tag);

            if (response)
            {
                Alert("Sucesso!", "A Tag foi cadastrada.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar a tag, contate a equipe de suporte.", "danger");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var tag = await _tagService.GetTagById(id);

            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Tag tag)
        {
            var response = await _tagService.Editar(tag);

            if (response)
            {
                Alert("Sucesso!", "A Tag foi editada.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível editar esta tag, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int tagId)
        {
            bool result = await _tagService.Excluir(tagId);

            if (result)
            {
                Alert("Sucesso!", "A tag foi excluída.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível excluir a tag, contate a equipe de suporte.", "danger");
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
