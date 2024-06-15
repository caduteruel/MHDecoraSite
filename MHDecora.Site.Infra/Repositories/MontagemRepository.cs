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

            return listaMontagens;
        }

        public async Task<List<Montagem>> BuscarDestaque()
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.MontagemDestaque)
                                                                                        .Include(x => x.Categoria)
                                                                                        .ToListAsync();


            foreach (var item in listaMontagens)
            {
                item.CaminhoImagem = @"/montagem/" + item.CaminhoImagem;
                item.CaminhoImagem2 = @"/montagem/" + item.CaminhoImagem2;
                item.CaminhoImagem3 = @"/montagem/" + item.CaminhoImagem3;
                item.CaminhoImagem4 = @"/montagem/" + item.CaminhoImagem4;

            }

            return listaMontagens;
        }

        public async Task<List<Montagem>> BuscarPorCategoria(int categoriaId)
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.CategoriaId == categoriaId)
                                                           .Include(x => x.Categoria)
                                                           .ToListAsync();

            foreach (var item in listaMontagens)
            {
                item.CaminhoImagem = @"/montagem/" + item.CaminhoImagem;
                item.CaminhoImagem2 = @"/montagem/" + item.CaminhoImagem2;
                item.CaminhoImagem3 = @"/montagem/" + item.CaminhoImagem3;
                item.CaminhoImagem4 = @"/montagem/" + item.CaminhoImagem4;

            }

            return listaMontagens;
        }

        public async Task<Montagem> BuscarPorId(int montagemId)
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.Id == montagemId).FirstOrDefaultAsync();


            listaMontagens.CaminhoImagem = @"/montagem/" + listaMontagens.CaminhoImagem;
            listaMontagens.CaminhoImagem2 = @"/montagem/" + listaMontagens.CaminhoImagem2;
            listaMontagens.CaminhoImagem3 = @"/montagem/" + listaMontagens.CaminhoImagem3;
            listaMontagens.CaminhoImagem4 = @"/montagem/" + listaMontagens.CaminhoImagem4;


            return listaMontagens;
        }

        private string GetMontagemPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
