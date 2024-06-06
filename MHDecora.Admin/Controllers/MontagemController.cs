using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Application.Services;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MHDecora.Admin.Controllers
{
    public class MontagemController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMontagemService _montagemService;
        private readonly ICategoriaService _categoriaService;

        public MontagemController(IMontagemService montagemService, ICategoriaService categoriaService, ITagService tagService)
        {
            _montagemService = montagemService;
            _categoriaService = categoriaService;
            _tagService = tagService;
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
            var categorias = await _categoriaService.GetCategorias();

            ViewBag.Tags = await _tagService.GetTags();

            return View(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4, List<string> tag)
        {
            var response = await _montagemService.Salvar(montagem, arquivo1, arquivo2, arquivo3, arquivo4, tag);

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
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _montagemService.GetById(id);

            var listaCategoria = await _categoriaService.GetCategorias();
          
            ViewBag.Categorias = new SelectList(listaCategoria, "Id", "Nome");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4, List<string> tag)
        {
            var response = await _montagemService.Editar(montagem, arquivo1, arquivo2, arquivo3, arquivo4, tag);

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
