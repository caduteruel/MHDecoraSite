using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace MHDecora.Admin.Infra.Repositories
{
    public class MontagemRepository : IMontagemRepository
    {
        public readonly AdminContext _adminContext;
        private readonly IConfiguration _configuration;

        public MontagemRepository(AdminContext adminContext, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _configuration = configuration;
        }

        public async Task<List<Montagem>> Buscar()
        {
            var listaMontagem = await _adminContext.MH_MONTAGEM.ToListAsync();

            foreach (var img in listaMontagem)
            {
                img.CaminhoImagem = GetMontagemPath() + img.CaminhoImagem;
                img.CaminhoImagem2 = GetMontagemPath() + img.CaminhoImagem2;
                img.CaminhoImagem3 = GetMontagemPath() + img.CaminhoImagem3;
                img.CaminhoImagem4 = GetMontagemPath() + img.CaminhoImagem4;
            }


            //List<Montagem> lista = new List<Montagem>();

            //var item1 = new Montagem() { 
            //    Id = 1,
            //    CaminhoImagem = "../images/montagens/quemsomos83dc2d91-b908-4338-ab7d-495a12c62734_1703857389655.jfif",
            //    LinkBotao = "/teste.html",
            //    Texto = "Testo safsdf asdf asdf sadff.",
            //    TextoImagem = "Imagem",
            //    Titulo = "Título das montagens"
            //};

            //lista.Add(item1);
            //lista.Add(item1);
            //lista.Add(item1);
            //lista.Add(item1);

            return listaMontagem;
        }

        public async Task<Montagem> GetById(int montagemId)
        {
            try
            {
                var response = await _adminContext.MH_MONTAGEM.FindAsync(montagemId);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await _adminContext.DisposeAsync();
            }
        }

        public async Task<bool> Excluir(int montagemId)
        {
            try
            {
                // Obtém o caminho completo da imagem do banner pelo ID
                string imagePath = await _adminContext.MH_MONTAGEM
                                                                .Where(b => b.Id == montagemId)
                                                                .Select(b => b.CaminhoImagem)
                                                                .FirstOrDefaultAsync();

                if (imagePath != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath);

                    // Exclui o registro do banner
                    var montagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(montagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine("wwwroot", "images\\montagem", fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }

                    //return true;
                }
                string imagePath2 = await _adminContext.MH_MONTAGEM
                                                .Where(b => b.Id == montagemId)
                                                .Select(b => b.CaminhoImagem2)
                                                .FirstOrDefaultAsync();

                if (imagePath2 != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath2);

                    // Exclui o registro do banner
                    var montagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(montagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine("wwwroot", "images\\montagem", fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }

                    //return true;
                }
                string imagePath3 = await _adminContext.MH_MONTAGEM
                                                .Where(b => b.Id == montagemId)
                                                .Select(b => b.CaminhoImagem3)
                                                .FirstOrDefaultAsync();

                if (imagePath3 != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath3);

                    // Exclui o registro do banner
                    var montagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(montagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine("wwwroot", "images\\montagem", fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }

                    //return true;
                }
                string imagePath4 = await _adminContext.MH_MONTAGEM
                                                .Where(b => b.Id == montagemId)
                                                .Select(b => b.CaminhoImagem4)
                                                .FirstOrDefaultAsync();

                if (imagePath4 != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath4);

                    // Exclui o registro do banner
                    var montagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(montagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine("wwwroot", "images\\montagem", fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }

                    //return true;
                }
                if(imagePath != null || imagePath2 != null || imagePath3 != null || imagePath4 != null)
                {
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

        public async Task<bool> Salvar(Montagem montagem, IFormFile arquivo)
        {
            try
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/montagem");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem = uniqueFileName;
                }

                _adminContext.MH_MONTAGEM.Add(montagem);

                await _adminContext.SaveChangesAsync();

                return true;
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

        //public async Task Criar(Banner banner, IFormFile imagem)
        //{
        //    //List<Banner> _banners = new List<Banner>();

        //        try
        //        {
        //            if (imagem != null && imagem.Length > 0)
        //            {
        //                //banner.Descricao = banner.CaminhoImagem;
        //                string roothPath = Directory.GetCurrentDirectory();
        //                string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/banner");
        //                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;
        //                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //                using (var fileStream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    imagem.CopyTo(fileStream);
        //                }
        //                banner.CaminhoImagem = uniqueFileName;
        //            }

        //            //_banners.Add(banner);

        //        _adminContext.MH_BANNERS.Add(banner);
        //        await _adminContext.SaveChangesAsync();


        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            await _adminContext.DisposeAsync();
        //        }
        //}

        //public async Task <List<Banner>> GetBanners() 
        //{
        //    var listaBanner = await _adminContext.MH_BANNERS.ToListAsync();

        //    foreach(var img in listaBanner)
        //    {
        //        img.CaminhoImagem = GetBannerPath() + img.CaminhoImagem;
        //    }

        //    return listaBanner;
        //}

        //public async Task<Banner> GetById(int id)
        //{
        //    Banner imagem = await _adminContext.MH_BANNERS.FirstOrDefaultAsync(x => x.Id == id);

        //    imagem.CaminhoImagem = GetBannerPath() + imagem.CaminhoImagem;

        //    return imagem;
        //}




        //}

        //public async Task<bool> Editar(IFormFile arquivo, Banner banner)
        //{
        //    var bannerExistente = await _adminContext.MH_BANNERS.FindAsync(banner.Id);


        //    if (bannerExistente == null)
        //    {
        //        return false;
        //    }

        //    banner.CaminhoImagem = bannerExistente.CaminhoImagem;

        //    if (arquivo != null)
        //    {
        //        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");
        //        var nomeArquivoAntigo = bannerExistente.CaminhoImagem;
        //        var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
        //        File.Delete(caminhoCompletoAntigo);


        //        var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
        //        var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

        //        using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
        //        {
        //            arquivo.CopyTo(fileStream);
        //        }

        //        banner.CaminhoImagem = nomeArquivoNovo;

        //    }

        //    _adminContext.Entry(bannerExistente).CurrentValues.SetValues(banner);

        //    //_adminContext.Entry(banner).State = EntityState.Modified;
        //    await _adminContext.SaveChangesAsync();

        //    return true;
        //}

        private string GetMontagemPath()
        {
            return  _configuration["ImagePath:Montagem"];
        }
    }
}
