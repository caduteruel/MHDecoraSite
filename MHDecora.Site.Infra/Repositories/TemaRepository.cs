using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public TemaRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Tema>> Buscar()
        {
            var listaTemas = await _context.MH_TEMA.ToListAsync();

            foreach (var item in listaTemas)
            {
                item.CaminhoImagem = @"/tema/" + item.CaminhoImagem;
            }

            return listaTemas;
        }

        private string GetTemaPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
