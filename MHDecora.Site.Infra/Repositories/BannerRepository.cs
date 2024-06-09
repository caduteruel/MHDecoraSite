using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using MHDecora.Admin.Infra;
using MHDecora.Site.Domain.Mappers;

namespace MHDecora.Site.Infra.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly PathOptions _adminRootPath;
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;
        private readonly AdminContext _adminContext;


        public BannerRepository(SiteContext context, IConfiguration configuration, PathOptions adminRootPath, 
            IHostingEnvironment hostingEnvironment, AdminContext adminContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _configuration = configuration;
            _adminRootPath = adminRootPath;
            _adminContext = adminContext;
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
            var listaBanner = await _adminContext.MH_BANNERS
                                     .OrderBy(b => b.Ordem) 
                                     .Take(3) 
                                     .ToListAsync();

            foreach (var img in listaBanner)
            {
                img.CaminhoImagem = GetBannerPath() + img.CaminhoImagem;
            }

            return listaBanner.ToSiteModel();
        }

        private string GetBannerPath()
        {
            //string caminho = Path.Combine("..", "MhDecora.Admin", "wwwroot", "images/banner/");

            //string filePath = Path.Combine(_adminRootPath.ToString(), "banner");
            //return caminho;
            return _configuration["ImagePath:Banner"];
        }
    }
}
