

using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace MHDecora.Site.Infra.CrossCutting
{
    public class InstagramAccess : IInstagramRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerSettings serializerSettings;
        private readonly Instagram _instagram;

        public InstagramAccess(IOptions<Instagram> instagram)
        {
            _instagram = instagram.Value;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            serializerSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };

            _client = new HttpClient()
            {
                BaseAddress = new Uri(_instagram.Url)
            };

            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

        }

        public async Task<dynamic> GetRecentsPosts()
        {
            using (var response = await _client.GetAsync("/me/media?fields=id,caption,media_url,media_type,timestamp,children{media_url}&limit=" + _instagram.Limit + "&access_token=" + _instagram.Token))
            {
                var contentResponse = await response.Content.ReadAsStringAsync();
              
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return JsonConvert.DeserializeObject<dynamic>(contentResponse, serializerSettings);
                    default:
                        throw new Exception($"Ocorreu um erro na integração com a plataforma! Verificar erro: {JsonConvert.DeserializeObject(contentResponse, serializerSettings)}");
                }
            }
        }
    }
}
