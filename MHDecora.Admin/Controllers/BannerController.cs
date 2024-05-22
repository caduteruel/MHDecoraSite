using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class BannerController : Controller
    {
        private readonly List<Banner> _banners;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBannerService _bannerService;

        public BannerController(IWebHostEnvironment webHostEnvironment, IBannerService bannerService)
        {
            _banners = new List<Banner>();
            _webHostEnvironment = webHostEnvironment;
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            
            var banners = await _bannerService.GetBanners();
            return View(banners);
        }

        //[HttpGet]
        //public async Task<IActionResult> Criar(Banner banner, IFormFile imagem)
        //{
        //    await _bannerService.Criar(banner, imagem);
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Criar(Banner banner, IFormFile imagem)
        {
            await _bannerService.Criar(banner, imagem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Banner banner, IFormFile imagem)
        {
            await _bannerService.Criar(banner, imagem);
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
            await _bannerService.Excluir(bannerId);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int bannerId)
        {
            var responde = await _bannerService.Editar(bannerId);

            return View(responde);
        }
    }
}
