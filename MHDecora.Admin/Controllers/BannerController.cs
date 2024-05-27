using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MHDecora.Admin.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _bannerService.GetBanners();

            return View(banners);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Banner banner, IFormFile imagem)
        {
            await _bannerService.Criar(banner, imagem);

            Alert("Sucesso!", "O Banner foi cadastrado.", "success");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Banner banner, IFormFile arquivo)
        {
            await _bannerService.Criar(banner, arquivo);

            Alert("Sucesso!", "O Banner foi cadastrado.", "success");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int bannerId)
        {
            bool result = await _bannerService.Excluir(bannerId);

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
        public async Task<IActionResult> GetBannerById(int bannerId)
        {
            await _bannerService.GetBannerById(bannerId);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int bannerId)
        {
            var banner = await _bannerService.GetBannerById(bannerId);

            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile arquivo, Banner banner)
        {
            var result = await _bannerService.Editar(arquivo, banner);

            if (result)
            {
                Alert("Sucesso!", "O Banner foi editado.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível editar o banner, contate a equipe de suporte.", "danger");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Configurar()
        {
            return View();
        }

        private void Alert(string titulo, string mensagem, string alerta)
        {
            TempData["Titulo"] = titulo;
            TempData["Mensagem"] = mensagem;
            TempData["TipoAlerta"] = alerta;
        }
    }
}
