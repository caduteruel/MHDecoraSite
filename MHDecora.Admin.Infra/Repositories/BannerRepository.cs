using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public BannerRepository(AdminContext adminContext)
        {
            _adminContext = adminContext;
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

        public async Task<Banner> GetById(int id)
        {
            return await _adminContext.MH_BANNERS.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Excluir(int bannerId)
        {
            try
            {
                // Obtém o caminho completo da imagem do banner pelo ID
                string imagePath = await _adminContext.MH_BANNERS
                    .Where(b => b.Id == bannerId)
                    .Select(b => b.CaminhoImagem)
                    .FirstOrDefaultAsync();

                if (imagePath != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath);

                    // Exclui o registro do banner
                    var banner = new Banner { Id = bannerId };
                    _adminContext.Entry(banner).State = EntityState.Deleted;
                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine("wwwroot", "images\\banner", fileName);
                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }

                    return true;
                }
                else
                {
                    // Se o caminho da imagem não for encontrado, retorna false indicando que o banner não foi encontrado
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, você pode lidar com ele aqui
                // Por exemplo, logar o erro ou retornar false
                Console.WriteLine($"Erro ao excluir banner: {ex.Message}");
                return false;
            }


        }
    }
}
