using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Infra.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        public readonly AdminContext _context;
        public BannerRepository(AdminContext context)
        {
            _context = context;
        }

        public async Task Criar(Banner banner, IFormFile imagem)
        {
            List<Banner> _banners = new List<Banner>();
            if (imagem != null && imagem.Length > 0)
            {
                string uploadsFolder = Path.Combine(banner.CaminhoImagem, "images/banner");
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
