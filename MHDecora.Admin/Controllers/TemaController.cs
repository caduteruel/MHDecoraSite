using Azure;
using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Application.Services;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MHDecora.Admin.Controllers
{
    [Authorize]
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
                return View(response);
            }

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            ViewBag.Tags = await _tagService.GetTags();

            return View();
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
        public async Task<IActionResult> Editar(int id)
        {
            var tema = await _temaService.BuscarPorId(id);

            var listaTags = await _tagService.GetTags();

            ViewBag.Tags = new SelectList(listaTags, "Id", "Nome");

            return View(tema);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile arquivo, Tema tema, List<string> tag)
        {
            var result = await _temaService.Editar(arquivo, tema, tag);

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
