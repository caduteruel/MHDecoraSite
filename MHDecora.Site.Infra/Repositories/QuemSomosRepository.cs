using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repositories
{
    public class QuemSomosRepository : IQuemSomosRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;
        
        public QuemSomosRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<QuemSomos> Buscar()
        {
            var quemSomos = await _context.MH_QUEMSOMOS
                                   .OrderByDescending(q => q.Id)
                                   .FirstOrDefaultAsync();

            if (quemSomos != null)
            {
                quemSomos.CaminhoImagem = GetPathImagens() + quemSomos.CaminhoImagem;
            }

            return quemSomos;
        }

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/quemsomos/";
        }
    }
}
