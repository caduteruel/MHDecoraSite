using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Infra.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        public readonly AdminContext _context;
        public readonly ILogger _logger;
        public BannerRepository(AdminContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Criar(Banner banner, IFormFile imagem)
        {
            List<Banner> _banners = new List<Banner>();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (imagem != null && imagem.Length > 0)
                    {
                        banner.Descricao = banner.CaminhoImagem;
                        string roothPath = Directory.GetCurrentDirectory();
                        string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/banner");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            imagem.CopyTo(fileStream);
                        }
                        banner.CaminhoImagem = "/banner/" + uniqueFileName;
                    }

                    banner.Id = Guid.NewGuid();
                    _banners.Add(banner);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Ocorreu um erro ao tentar salvar o banner no banco de dados.");
                    throw;
                }

            }
        }

        public async Task <List<Banner>> GetBanners() 
        {
            var banners = new List<Banner>();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");

            if (Directory.Exists(imagePath))
            {
                var files = Directory.GetFiles(imagePath);
                foreach (var file in files)
                {
                    var banner = new Banner
                    {
                        Id = Guid.NewGuid(), // Gere um ID único para cada banner
                        Descricao = Path.GetFileNameWithoutExtension(file),
                        CaminhoImagem = Path.Combine("~/images/banner", Path.GetFileName(file))
                    };
                    banners.Add(banner);
                }
            }

            return banners;
        }

        public Task<Banner> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
