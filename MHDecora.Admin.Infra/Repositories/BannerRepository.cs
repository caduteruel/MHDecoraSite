using InstaSharper.Classes.Models;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MHDecora.Admin.Infra.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        public readonly AdminContext _adminContext;
        private readonly IConfiguration _configuration;

        public BannerRepository(AdminContext adminContext, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _configuration = configuration;
        }

        public async Task Criar(Banner banner, IFormFile imagem)
        {
            try
            {
                if (imagem != null && imagem.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;

                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/banner/", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                    {
                        imagem.CopyTo(fileStream);
                    }

                    banner.CaminhoImagem = uniqueFileName;
                }

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
            var listaBanner = await _adminContext.MH_BANNERS.ToListAsync();

            foreach (var img in listaBanner)
            {
                img.CaminhoImagem = GetPathImagens() + img.CaminhoImagem;
            }

            return listaBanner;
        }

        public async Task<Banner> GetById(int id)
        {
            Banner imagem = await _adminContext.MH_BANNERS.FirstOrDefaultAsync(x => x.Id == id);
            
            imagem.CaminhoImagem = GetPathImagens() + imagem.CaminhoImagem;
            
            return imagem;
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
                    string imagePathToDelete = Path.Combine(GetPathImagens(), fileName);

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

        public async Task<bool> Editar(IFormFile arquivo, Banner banner)
        {
            var bannerExistente = await _adminContext.MH_BANNERS.FindAsync(banner.Id);

            if (bannerExistente == null)
            {
                return false;
            }

            _adminContext.Entry<Banner>(bannerExistente).State = EntityState.Detached;

            if (!banner.Status1) banner.CaminhoImagem = bannerExistente.CaminhoImagem;

            if (banner.Status1)
            {
                DeleteFile(Path.Combine("/var/aspnetcore/mhdecora_imagens/banner/", bannerExistente.CaminhoImagem));
                if (arquivo != null)
                {
                    banner.CaminhoImagem = SaveFile(arquivo);
                }
            }

            void DeleteFile(string path)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }

            // Função para salvar novo arquivo
            string SaveFile(IFormFile arquivo)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/banner/", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo.CopyTo(fileStream);
                }

                banner.CaminhoImagem = uniqueFileName;

                return uniqueFileName;
            }

            //banner.CaminhoImagem = bannerExistente.CaminhoImagem;

            //if (arquivo != null)
            //{
            //    var nomeArquivoAntigo = bannerExistente.CaminhoImagem;

            //    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/banner/", nomeArquivoAntigo);

            //    File.Delete(filePath);

            //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;

            //    filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/banner/", uniqueFileName);
                        

            //    using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
            //    {
            //        arquivo.CopyTo(fileStream);
            //    }

            //    banner.CaminhoImagem = uniqueFileName;
            //}

            //_adminContext.Entry(bannerExistente).CurrentValues.SetValues(banner);
            
            _adminContext.Entry(banner).State = EntityState.Modified;
            await _adminContext.SaveChangesAsync();

            return true;
        }

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/banner/";
        }
    }
}
