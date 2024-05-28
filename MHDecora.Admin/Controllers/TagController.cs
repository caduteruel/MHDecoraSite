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

        [HttpPost]
        public async Task<IActionResult> Salvar(Tag tag)
        {
            await _tagService.Criar(tag);

            Alert("Sucesso!", "A Tag foi cadastrada.", "success");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var tag = await _tagService.GetTagById(id);

            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            bool result = await _tagService.Excluir(id);

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
