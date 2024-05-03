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

        public HomeController(ILogger<HomeController> logger, IBannerService bannerService, IQuemSomosService quemSomosService, IMontagemService montagemService, ITemaService temaService)
        {
            _logger = logger;
            _bannerService = bannerService;
            _quemSomosService = quemSomosService;
            _montagemService = montagemService;
            _temaService = temaService;
        }

        public async Task<IActionResult> Index()
        {
            //Banners
            List<Banner> banner = await _bannerService.BuscarTodos();

            //Quem Somos
            QuemSomos quemSomos = await _quemSomosService.Buscar();

            //Montagens
            List<Montagem> montagem = await _montagemService.Buscar();
            
            //Temas
            List<Tema> tema = await _temaService.Buscar();
            
            //ViewModel
            SiteViewModel siteViewModel = new SiteViewModel();
            siteViewModel.Banners = banner;
            siteViewModel.QuemSomos = quemSomos;
            siteViewModel.Montagens = montagem;
            siteViewModel.Temas = tema;

            return View(siteViewModel);
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
