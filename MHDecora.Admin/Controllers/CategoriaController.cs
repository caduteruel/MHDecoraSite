using Azure;
using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Salvar(Categoria categoria, IFormFile imagem)
        {
            var response = await _categoriaService.Criar(categoria, imagem);

            if (response)
            {
                Alert("Sucesso!", "A Categoria foi cadastrada.", "success");

            }
            else
            {
                Alert("Erro!", "Não foi possível criar a categoria, contate a equipe de suporte.", "danger");

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _categoriaService.GetCategoriaById(id);

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile arquivo, Categoria categoria)
        {
            var response = await _categoriaService.Editar(categoria, arquivo);

            if (response)
            {
                Alert("Sucesso!", "A Categoria foi editada.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar esta categoria, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int categoriaId)
        {
            bool result = await _categoriaService.Excluir(categoriaId);

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

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Categoria categoria, IFormFile arquivo)
        {
            var response = await _categoriaService.Criar(categoria, arquivo);

            if (response)
            {
                Alert("Sucesso!", "A Categoria foi cadastrada.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível criar esta categoria, contate a equipe de suporte.", "danger");
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
