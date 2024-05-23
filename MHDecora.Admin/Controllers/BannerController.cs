using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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

            //List<Banner> bannerList = new List<Banner>();

            //Banner banner = new Banner();
            //banner.Id = 1;
            //banner.CaminhoImagem = "../images/banner/imagem1.jpeg";
            //banner.Ordem = 1;
            //banner.Descricao = "/Teste";

            //bannerList.Add(banner);

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

        [HttpGet]
        public async Task<IActionResult> Editar(int bannerId)
        {
            var banner = await _bannerService.GetBannerById(bannerId);
            //Banner banner = new Banner();
            //banner.Id = 1;
            //banner.CaminhoImagem = "../images/banner/imagem1.jpeg";
            //banner.Ordem = 1;
            //banner.Descricao = "/Teste";

            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile arquivo, Banner banner)
        {

            var result = await _bannerService.Editar(arquivo, banner);

            if (!result)
            {
                return BadRequest("Banner não encontrado.");
            }

            return Ok("Index");
        }

        public class ArquivoViewModel
        {
            public IFormFile Arquivo { get; set; }
        }

        private void Alert(string titulo, string mensagem, string alerta)
        {
            TempData["Titulo"] = titulo;
            TempData["Mensagem"] = mensagem;
            TempData["TipoAlerta"] = alerta;
        }
    }
}
