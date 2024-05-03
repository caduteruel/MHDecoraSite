using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Site.Infra.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly SiteContext _context;

        public BannerRepository(SiteContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Banner entity)
        {
            _context.Banners.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Apagar(int id)
        {
            var entity = await _context.Banners.FindAsync(id);
            _context.Banners.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Banner entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Banner> BuscarPorId(int id)
        {
            return await _context.Banners.FindAsync(id);
        }

        public async Task<List<Banner>> BuscarTodos()
        {
            List<Banner> listaBanners =
            [
                new Banner("/image/img1.jpg")
                {
                    Id = 1
                },
                new Banner("/image/img2.jpg")
                {
                    Id = 2
                },
                new Banner("/image/img3.jpg")
                {
                    Id = 3
                },
            ];
           // return await _context.Banners.ToListAsync();

            return listaBanners;
        }
    }
}
