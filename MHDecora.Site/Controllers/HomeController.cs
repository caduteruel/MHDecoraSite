using MHDecora.Site.Application;
using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDeroca.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace MHDeroca.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<HomeController> _logger;
        private readonly IBannerService _bannerService;
        private readonly IQuemSomosService _quemSomosService;
        private readonly IMontagemService _montagemService;
        private readonly ITemaService _temaService;
        private readonly IContatoService _contatoService;
        private readonly IInstagramService _instagramService;

        public HomeController(ILogger<HomeController> logger, IBannerService bannerService, IQuemSomosService quemSomosService, 
            IMontagemService montagemService, ITemaService temaService, IContatoService contatoService, IInstagramService instagramService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _bannerService = bannerService;
            _quemSomosService = quemSomosService;
            _montagemService = montagemService;
            _temaService = temaService;
            _contatoService = contatoService;
            _instagramService = instagramService;
            _memoryCache = memoryCache;
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

            ////Novidades
            //if (!_memoryCache.TryGetValue("InstagramPostsCache", out JObject cacheValue))
            //{
            //    cacheValue = _instagramService.GetRecentsPosts().Result;

            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(2));

            //    _memoryCache.Set("InstagramPostsCache", cacheValue, cacheEntryOptions);
            //}

            //ViewBag.InstagramPosts = cacheValue;

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
           
            return View("Consulta", montagens);
        }

        [HttpGet]
        public async Task<IActionResult> Rodape()
        {
            List<Montagem> montagem = await _montagemService.Buscar();

            var link = new List<object>
            {
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = montagem[0].CategoriaId }), Nome = montagem[0].Titulo },
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = montagem[1].CategoriaId }), Nome = montagem[1].Titulo },
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = montagem[2].CategoriaId }), Nome = montagem[2].Titulo },
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = montagem[3].CategoriaId }), Nome = montagem[3].Titulo }
            };

            return Json(link); // Retorna os dados como JSON
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
