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
            bool result = await _bannerService.Excluir(bannerId);
            if (result)
            {
                return Ok("Banner excluído com Sucesso");
            }
            else
            {
                return BadRequest("Não foi possível excluir o Banner. Verifique.");
            }           
        }

        [HttpGet]
        public async Task<IActionResult> GetBannerById(int bannerId)
        {
            await _bannerService.GetBannerById(bannerId);
            return Ok();
        }
    }
}
