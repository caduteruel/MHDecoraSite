using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
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
        public readonly AdminContext _adminContext;
        public readonly ILogger _logger;
        public BannerRepository(AdminContext adminContext, ILogger logger)
        {
            _adminContext = adminContext;
            _logger = logger;
        }

        public async Task Criar(Banner banner, IFormFile imagem)
        {
            //List<Banner> _banners = new List<Banner>();

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

                    //_banners.Add(banner);

                _adminContext.MH_BANNERS.Add(banner);
                await _adminContext.SaveChangesAsync();
               

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ocorreu um erro ao tentar salvar o banner no banco de dados.");
                    throw;
                }
                finally
                {
                    await _adminContext.DisposeAsync();
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

        public async Task Excluir(int bannerId)
        {
            //var banners = new List<Banner>();
            //var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");

            //if (Directory.Exists(imagePath))
            //{
            //    var files = Directory.GetFiles(imagePath);
            //    foreach (var file in files)
            //    {
            //        var banner = new Banner
            //        {
            //            Id = Guid.NewGuid(), // Gere um ID único para cada banner
            //            Descricao = Path.GetFileNameWithoutExtension(file),
            //            CaminhoImagem = Path.Combine("~/images/banner", Path.GetFileName(file))
            //        };
            //        banners.Add(banner);
            //    }
            //}

            // 1 - Consultar o nome do arquivo pelo bannerId
            // 2 - Excluir a imagem
            // 3 - Excluir o registro

            
        }
    }
}
