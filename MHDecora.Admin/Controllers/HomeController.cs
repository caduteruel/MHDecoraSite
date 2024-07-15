using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Interfaces;
using MHDecora.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace MHDecora.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMidiaSocialService _midiasService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,
            IMidiaSocialService midiasService)
        {
            _logger = logger;
            _configuration = configuration;
            _midiasService = midiasService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // Para tratar erro no login
            ViewBag.Erro = TempData["Erro"];

            return View();
        }
        
        public IActionResult Inicio()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string email, string password)
        {
            if (ModelState.IsValid)
            {
                string emailConfig = _configuration["Access:Email"].ToString();
                string passwordConfig = _configuration["Access:Password"].ToString();

                if (emailConfig.Equals(email) && password.Equals(passwordConfig))
                {
                    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);

                    // Adicionar a reivindicação do ID do usuário
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1".ToString()));

                    // Adicionar a reivindicação do nome de usuário
                    identity.AddClaim(new Claim(ClaimTypes.Name, "login"));

                    // Exemplo de como adicionar outras reivindicações baseadas nas configurações
                    identity.AddClaim(new Claim(ClaimTypes.Email, emailConfig));

                    // Exemplo de como adicionar uma reivindicação de papel (role) fixo
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                    // Finalmente, você pode criar o ClaimsPrincipal com base na identidade
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction(nameof(HomeController.Inicio), "Home");
                }
            }

            TempData["Erro"] = "true";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
