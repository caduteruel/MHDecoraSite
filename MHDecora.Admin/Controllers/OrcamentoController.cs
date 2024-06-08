using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHDecora.Admin.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoController(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Orcamento orcamento)
        {
            var response = await _orcamentoService.Salvar(orcamento);

            if (response)
            {
                Alert("Sucesso!", "Orçamento enviado, aguarde nosso contato.", "success");
            }
            else
            {
                Alert("Erro!", "Não foi possível enviar o orçamento, contate por telefone.", "danger");
            }

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
