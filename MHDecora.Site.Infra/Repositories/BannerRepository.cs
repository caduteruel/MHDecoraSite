using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public BannerRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Adicionar(Banner entity)
        {
            _context.MH_BANNERS.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Apagar(int id)
        {
            var entity = await _context.MH_BANNERS.FindAsync(id);
            _context.MH_BANNERS.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Banner entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Banner> BuscarPorId(int id)
        {
            return await _context.MH_BANNERS.FindAsync(id);
        }

        public async Task<List<Banner>> BuscarTodos()
        {
            var listaBanner = await _context.MH_BANNERS.ToListAsync();

            foreach (var img in listaBanner)
            {
                img.CaminhoImagem = GetBannerPath() + img.CaminhoImagem;
            }

            return listaBanner;
        }

        private string GetBannerPath()
        {
            return _configuration["ImagePath:Banner"];
        }
    }
}
