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

            //var banners = await _bannerService.GetBanners();

            List<Banner> bannerList = new List<Banner>();

            Banner banner = new Banner();
            banner.Id = 1;
            banner.CaminhoImagem = "../images/banner/imagem1.jpeg";
            banner.Ordem = 1;
            banner.Descricao = "/Teste";

            bannerList.Add(banner);

            return View(bannerList);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Banner banner, IFormFile imagem)
        {
            await _bannerService.Criar(banner, imagem);
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
            //var responde = await _bannerService.Editar(bannerId);
            Banner banner = new Banner();
            banner.Id = 1;
            banner.CaminhoImagem = "../images/banner/imagem1.jpeg";
            banner.Ordem = 1;
            banner.Descricao = "/Teste";

            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(IFormFile arquivo, Banner banner)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                // Lógica para lidar com o envio sem arquivo selecionado
                return BadRequest("Nenhum arquivo selecionado.");
            }

            // Lógica para salvar o arquivo
            var filePath = Path.Combine("wwwroot/banner", arquivo.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            // Lógica para redirecionar ou retornar uma resposta
            return RedirectToAction("Index", "Home");
        }

        public class ArquivoViewModel
        {
            public IFormFile Arquivo { get; set; }
        }
    }
}
