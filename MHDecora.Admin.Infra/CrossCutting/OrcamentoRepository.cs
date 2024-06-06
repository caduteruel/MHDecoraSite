using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace MHDecora.Admin.Infra.CrossCutting
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public OrcamentoRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> Salvar(Orcamento orcamento)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Orcamento:API");
                var conteudo = new StringContent(JsonConvert.SerializeObject(orcamento), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress + "/Orcamento/enviar", conteudo);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Lida com exceções, registre ou lance exceções se necessário.
                throw new Exception($"Erro interno: {ex.Message}");
            }
        }
    }
}
