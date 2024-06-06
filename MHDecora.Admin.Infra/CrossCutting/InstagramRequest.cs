using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Logger;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces.CrossCutting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace MHDecora.Admin.Infra.CrossCutting
{
    public class InstagramRequest
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        private static string Username = "";
        private static string Pasword = "";

        private UserSessionData data = new UserSessionData();
        public IInstaApi instaApi { get; set; }

        public InstagramRequest(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }


        public async Task<bool> GetImagens()
        {
            try
            {
                instaApi = InstaApiBuilder.CreateBuilder().SetUser(data).UseLogger(new DebugLogger(LogLevel.Exceptions)).Build();
                var logRequest = await instaApi.LoginAsync();

                if (logRequest.Succeeded)
                {
                }
                else
                {

                }

                return true;
            }
            catch (Exception ex)
            {
                // Lida com exceções, registre ou lance exceções se necessário.
                throw new Exception($"Erro interno: {ex.Message}");
            }
        }
    }
}
