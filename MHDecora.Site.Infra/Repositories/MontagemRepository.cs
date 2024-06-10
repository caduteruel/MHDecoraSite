using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repositories
{
    public class MontagemRepository : IMontagemRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public MontagemRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Montagem>> Buscar()
        {
            var listaMontagens = await _context.MH_MONTAGEM.ToListAsync();

            foreach (var img in listaMontagens)
            {
                img.CaminhoImagem = @"/montagem/" + img.CaminhoImagem;
            }

            return listaMontagens;
        }

        public async Task<List<Montagem>> BuscarDestaque()
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.MontagemDestaque)
                                                                                        .Include(x => x.Categoria)
                                                                                        .ToListAsync();

            foreach (var img in listaMontagens)
            {
                img.CaminhoImagem = @"/montagem/" + img.CaminhoImagem;
                img.CaminhoImagem2 = @"/montagem/" + img.CaminhoImagem;
                img.CaminhoImagem3 = @"/montagem/" + img.CaminhoImagem;
                img.CaminhoImagem4 = @"/montagem/" + img.CaminhoImagem;
            }

            return listaMontagens;
        }

        private string GetMontagemPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
