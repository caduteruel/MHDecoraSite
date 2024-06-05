using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Dynamic;
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
            var listaMontagem = await _adminContext.MH_MONTAGEM
                                                            .Include(m => m.Categoria) // Inclui os dados da categoria associada a cada montagem
                                                            .ToListAsync();

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

                response.CaminhoImagem = GetMontagemPath() + response.CaminhoImagem;
                response.CaminhoImagem2 = GetMontagemPath() + response.CaminhoImagem2;
                response.CaminhoImagem3 = GetMontagemPath() + response.CaminhoImagem3;
                response.CaminhoImagem4 = GetMontagemPath() + response.CaminhoImagem4;

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

        public async Task<bool> Salvar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4)
        {
            try
            {
                if (arquivo1 != null && arquivo1.Length > 0)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/montagem");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo1.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo1.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem = uniqueFileName;
                }
                if (arquivo2 != null && arquivo2.Length > 0)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/montagem");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo2.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo2.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem2 = uniqueFileName;
                }
                if (arquivo3 != null && arquivo3.Length > 0)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/montagem");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo3.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo3.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem3 = uniqueFileName;
                }
                if (arquivo4 != null && arquivo4.Length > 0)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/montagem");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo4.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo4.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem4 = uniqueFileName;
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

        public async Task<bool> Editar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4)
        {
            var montagemExistente = await _adminContext.MH_MONTAGEM.FindAsync(montagem.Id);


            if (montagemExistente == null)
            {
                return false;
            }

            montagem.CaminhoImagem = montagemExistente.CaminhoImagem;
            montagem.CaminhoImagem2 = montagemExistente.CaminhoImagem2;
            montagem.CaminhoImagem3 = montagemExistente.CaminhoImagem3;
            montagem.CaminhoImagem4 = montagem.CaminhoImagem4;

            if (arquivo1 != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
                File.Delete(caminhoCompletoAntigo);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo1.FileName;
                var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

                using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
                {
                    arquivo1.CopyTo(fileStream);
                }

                montagem.CaminhoImagem = nomeArquivoNovo;

            }

            if (arquivo2 != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
                File.Delete(caminhoCompletoAntigo);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo2.FileName;
                var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

                using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
                {
                    arquivo2.CopyTo(fileStream);
                }

                montagem.CaminhoImagem2 = nomeArquivoNovo;

            }

            if (arquivo3 != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
                File.Delete(caminhoCompletoAntigo);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo3.FileName;
                var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

                using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
                {
                    arquivo3.CopyTo(fileStream);
                }

                montagem.CaminhoImagem3 = nomeArquivoNovo;

            }

            if (arquivo4 != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banner");
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
                File.Delete(caminhoCompletoAntigo);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo4.FileName;
                var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

                using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
                {
                    arquivo4.CopyTo(fileStream);
                }

                montagem.CaminhoImagem4 = nomeArquivoNovo;

            }

            _adminContext.Entry(montagemExistente).CurrentValues.SetValues(montagem);

            //_adminContext.Entry(banner).State = EntityState.Modified;
            await _adminContext.SaveChangesAsync();

            return true;
        }

        private string GetMontagemPath()
        {
            return  _configuration["ImagePath:Montagem"];
        }
    }
}
