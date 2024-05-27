using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class QuemSomosController : Controller
    {
        private readonly IQuemSomosService _quemSomosService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public QuemSomosController(IQuemSomosService quemSomosService, IWebHostEnvironment webHostEnvironment)
        {
            _quemSomosService = quemSomosService;
            _webHostEnvironment = webHostEnvironment;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dados = await _quemSomosService.GetDados();

            if (dados != null)
            {
                var imageUrl = Url.Content($"~/images/quemsomos/{dados.CaminhoImagem}");

                var result = new
                {
                    Dados = dados,
                    ImageUrl = imageUrl
                };

                return Ok(result);
            }
            else
            {
                Alert("Erro!", "Não foi possível carregar os dados, contate a equipe de suporte.", "danger");
                return NotFound();
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(QuemSomos dados, IFormFile imagem)
        {
            await _quemSomosService.Salvar(dados, imagem);

            Alert("Sucesso!", "Seção Quem Somos foi atualizada.", "success");

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
