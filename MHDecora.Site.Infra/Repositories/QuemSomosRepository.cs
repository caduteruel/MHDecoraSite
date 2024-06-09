using MHDecora.Admin.Infra;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using MHDecora.Site.Domain.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repositories
{
    public class QuemSomosRepository : IQuemSomosRepository
    {
        private readonly SiteContext _context;
        private readonly AdminContext _adminContext;
        private readonly IConfiguration _configuration;
        
        public QuemSomosRepository(SiteContext context, IConfiguration configuration, AdminContext adminContext)
        {
            _context = context;
            _configuration = configuration;
            _adminContext = adminContext;
        }

        public async Task<QuemSomos> Buscar()
        {
            var quemSomos = await _adminContext.MH_QUEMSOMOS
                                   .OrderByDescending(q => q.Id)
                                   .FirstOrDefaultAsync();

            if (quemSomos != null)
            {
                quemSomos.CaminhoImagem = GetQuemSomosPath() + quemSomos.CaminhoImagem;
            }

            return quemSomos.ToSiteModel();
        }

        private string GetQuemSomosPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
