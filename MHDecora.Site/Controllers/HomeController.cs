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
        private readonly IMidiaSocialService _midiaSocialService;
        private readonly IBannerService _bannerService;
        private readonly IQuemSomosService _quemSomosService;
        private readonly IMontagemService _montagemService;
        private readonly ITemaService _temaService;
        private readonly IContatoService _contatoService;
        private readonly IInstagramService _instagramService;
        private readonly ICategoriaService _categoriaService;
        private readonly IOrcamentoService _orcamentoService;

        public HomeController(ILogger<HomeController> logger, IMidiaSocialService midiaSocialService, IBannerService bannerService, IQuemSomosService quemSomosService, 
            IMontagemService montagemService, ITemaService temaService, IContatoService contatoService, IInstagramService instagramService, IMemoryCache memoryCache, ICategoriaService categoriaService, IOrcamentoService orcamentoService)

        {
            _logger = logger;
            _midiaSocialService = midiaSocialService;
            _bannerService = bannerService;
            _quemSomosService = quemSomosService;
            _montagemService = montagemService;
            _temaService = temaService;
            _contatoService = contatoService;
            _instagramService = instagramService;
            _memoryCache = memoryCache;
            _categoriaService = categoriaService;
            _orcamentoService = orcamentoService;
        }

        public async Task<IActionResult> Index()
        {
            //Banners
            MidiaSocial midiaSocial = await _midiaSocialService.GetMidiaSocial();

            //Banners
            List<Banner> banner = await _bannerService.BuscarTodos();

            ////Quem Somos
            QuemSomos quemSomos = await _quemSomosService.Buscar();

            //Categorias
            List<Categoria> categorias = await _categoriaService.Buscar();

            ////Montagens
            List<Montagem> montagem = await _montagemService.Buscar();
            
            ////Temas
            List<Tema> tema = await _temaService.Buscar();

            ////Galeria
            List<Montagem> galeria = await _montagemService.BuscarDestaque();

            ////Galeria
            Contato contato = await _contatoService.GetContato();

            ////Novidades
            if (!_memoryCache.TryGetValue("InstagramPostsCache", out JObject cacheValue))
            {
                cacheValue = _instagramService.GetRecentsPosts().Result;

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(2));

                _memoryCache.Set("InstagramPostsCache", cacheValue, cacheEntryOptions);
            }

            ViewBag.InstagramPosts = cacheValue;

            ViewData["MidiaSocial"] = midiaSocial;

            //ViewModel
            SiteViewModel siteViewModel = new SiteViewModel();
            siteViewModel.Banners = banner;
            siteViewModel.QuemSomos = quemSomos;
            siteViewModel.Montagens = montagem;
            siteViewModel.Temas = tema;
            siteViewModel.Galerias = galeria;
            siteViewModel.Contato = contato;
            siteViewModel.Categorias = categorias;

            return View(siteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Pesquisa(string texto)
        {
            List<Montagem> montagens = await _montagemService.Pesquisa(texto);

            ViewData["MidiaSocial"] = await _midiaSocialService.GetMidiaSocial();

            ViewData["PalavraPesquisada"] = texto;

            return View(montagens);
        }

        [HttpGet]
        public async Task<IActionResult> Consulta(int categoriaId) 
        {
            List<Montagem> montagens = await _montagemService.BuscarPorCategoria(categoriaId);
            
            ViewData["MidiaSocial"] = await _midiaSocialService.GetMidiaSocial();
           
            return View(montagens);
        }

        [HttpGet]
        public async Task<IActionResult> Filtro(string filters, int categoriaId)
        {
            var result = await _montagemService.BuscarPorFiltro(categoriaId, filters);

            ViewData["MidiaSocial"] = await _midiaSocialService.GetMidiaSocial();

            return View("Consulta", result);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int montagemId)
        {
            Detalhe detalhe = await _montagemService.BuscarPorId(montagemId);

            ViewData["MidiaSocial"] = await _midiaSocialService.GetMidiaSocial();

            return View(detalhe);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaTagsTema(int temaId)
        {
            List<Montagem> montagens = await _montagemService.BuscarPorTagsTema(temaId);

            ViewData["MidiaSocial"] = await _midiaSocialService.GetMidiaSocial();

            return View(montagens);
        }

        [HttpGet]
        public async Task<IActionResult> Rodape()
        {
            List<Categoria> categoria = await _categoriaService.Buscar();

            var link = new List<object>
            {
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = categoria[0].Id }), Nome = categoria[0].Nome },
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = categoria[1].Id }), Nome = categoria[1].Nome },
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = categoria[2].Id }), Nome = categoria[2].Nome },
                new { Url = Url.Action("Consulta", "Home", new { categoriaId = categoria[3].Id }), Nome = categoria[3].Nome }
            };

            return Json(link); // Retorna os dados como JSON
        }

        [HttpPost]
        public async Task<IActionResult> Orcamento (Orcamento orcamento)
        {
            //var result = await _orcamentoService.EnviarOrcamento(orcamento);

            //validacao chamada acima
            //if (1 == 1)
            //{
            //    Alert("Sucesso!", "Orcamento enviado com sucesso.", "success");
            //}
            //else
            //{
            //    Alert("Erro!", "Não foi possível enviar o Orcamento, contate a equipe MH Decora.", "danger");
            //}

            return RedirectToAction("Index");

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
        private void Alert(string titulo, string mensagem, string alerta)
        {
            TempData["Titulo"] = titulo;
            TempData["Mensagem"] = mensagem;
            TempData["TipoAlerta"] = alerta;
        }

    }
}
