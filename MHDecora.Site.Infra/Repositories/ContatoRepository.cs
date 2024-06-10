using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public ContatoRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
              
        public async Task<Contato> Buscar()
        {
            var contato = await _context.MH_CONTATO.FirstOrDefaultAsync();

            return contato;
        }

        private string GetContatoPath()
        {
            return _configuration["ImagePath:Banner"];
        }
    }
}
