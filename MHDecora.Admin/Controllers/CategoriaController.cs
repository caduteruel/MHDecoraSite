using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategorias();

            return View(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoria)
        {
            await _categoriaService.Criar(categoria);

            Alert("Sucesso!", "A Categoria foi cadastrada.", "success");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var banner = await _categoriaService.GetCategoriaById(id);

            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            bool result = await _categoriaService.Excluir(id);

            if (result)
            {
                Alert("Sucesso!", "A categoria foi excluída.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível excluir a categoria, contate a equipe de suporte.", "danger");
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
