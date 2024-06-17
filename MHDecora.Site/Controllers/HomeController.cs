using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDeroca.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MHDeroca.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBannerService _bannerService;
        private readonly IQuemSomosService _quemSomosService;
        private readonly IMontagemService _montagemService;
        private readonly ITemaService _temaService;
        private readonly IContatoService _contatoService;

        public HomeController(ILogger<HomeController> logger, IBannerService bannerService, IQuemSomosService quemSomosService, 
            IMontagemService montagemService, ITemaService temaService, IContatoService contatoService)
        {
            _logger = logger;
            _bannerService = bannerService;
            _quemSomosService = quemSomosService;
            _montagemService = montagemService;
            _temaService = temaService;
            _contatoService = contatoService;
        }

        public async Task<IActionResult> Index()
        {
            //Banners
            List<Banner> banner = await _bannerService.BuscarTodos();

            ////Quem Somos
            QuemSomos quemSomos = await _quemSomosService.Buscar();

            ////Montagens
            List<Montagem> montagem = await _montagemService.Buscar();
            
            ////Temas
            List<Tema> tema = await _temaService.Buscar();

            ////Galeria
            List<Montagem> galeria = await _montagemService.BuscarDestaque();

            ////Galeria
            Contato contato = await _contatoService.GetContato();


            //ViewModel
            SiteViewModel siteViewModel = new SiteViewModel();
            siteViewModel.Banners = banner;
            siteViewModel.QuemSomos = quemSomos;
            siteViewModel.Montagens = montagem;
            siteViewModel.Temas = tema;
            siteViewModel.Galerias = galeria;
            siteViewModel.Contato = contato;

            return View(siteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Pesquisa(string texto)
        {
            List<Montagem> montagens = await _montagemService.Pesquisa(texto);

            return View(montagens);
        }

        [HttpGet]
        public async Task<IActionResult> Consulta(int categoriaId)
        {
            List<Montagem> montagens = await _montagemService.BuscarPorCategoria(categoriaId);

            return View(montagens);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int montagemId)
        {
            Montagem montagem = await _montagemService.BuscarPorId(montagemId);

            return View(montagem);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaTagsTema(int temaId)
        {
            List<Montagem> montagens = await _montagemService.BuscarPorTagsTema(temaId);

            if(montagens != null)
            {
                return View("Consulta", montagens);
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
