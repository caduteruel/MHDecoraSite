using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Diagnostics;
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
                img.CaminhoImagem = GetPathImagens() + img.CaminhoImagem;
                img.CaminhoImagem2 = GetPathImagens() + img.CaminhoImagem2;
                img.CaminhoImagem3 = GetPathImagens() + img.CaminhoImagem3;
                img.CaminhoImagem4 = GetPathImagens() + img.CaminhoImagem4;
            }

            return listaMontagem;
        }

        public async Task<Montagem> GetById(int montagemId)
        {
            try
            {
                var response = await _adminContext.MH_MONTAGEM.FindAsync(montagemId);

                response.CaminhoImagem = GetPathImagens() + response.CaminhoImagem;
                response.CaminhoImagem2 = GetPathImagens() + response.CaminhoImagem2;
                response.CaminhoImagem3 = GetPathImagens() + response.CaminhoImagem3;
                response.CaminhoImagem4 = GetPathImagens() + response.CaminhoImagem4;

                if(response.Tags != null)
                {
                    var listaTags = response.Tags.Split(",");
                    response.TagsList = new List<Tag>();

                    foreach (var tag in listaTags)
                    {
                        var tag2 = _adminContext.MH_TAGS.Where(x => x.Id.Equals(Convert.ToInt32(tag))).FirstOrDefault();
                        response.TagsList.Add(tag2);
                    }
                }
                
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Excluir(int montagemId)
        {
            try
            {
                // Obtém o caminho completo da imagem do banner pelo ID
                var montagem = await _adminContext.MH_MONTAGEM.Where(b => b.Id == montagemId).FirstOrDefaultAsync();

                if (montagem.CaminhoImagem != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(montagem.CaminhoImagem);

                    // Exclui o registro do banner
                    var imagemMontagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(imagemMontagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine(GetPathImagens(), fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }
                }

                if (montagem.CaminhoImagem2 != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(montagem.CaminhoImagem2);

                    // Exclui o registro do banner
                    var imagemMontagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(imagemMontagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine(GetPathImagens(), fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }
                }

                if (montagem.CaminhoImagem3 != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(montagem.CaminhoImagem3);

                    // Exclui o registro do banner
                    var imagemMontagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(imagemMontagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine(GetPathImagens(), fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }
                }

                if (montagem.CaminhoImagem4 != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(montagem.CaminhoImagem4);

                    // Exclui o registro do banner
                    var imagemMontagem = new Montagem { Id = montagemId };
                    _adminContext.Entry(imagemMontagem).State = EntityState.Deleted;

                    await _adminContext.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine(GetPathImagens(), fileName);

                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }
                }

                _adminContext.Entry(montagem).State = EntityState.Deleted;

                await _adminContext.SaveChangesAsync();

                if (montagem.CaminhoImagem != null || montagem.CaminhoImagem2 != null || montagem.CaminhoImagem3 != null || montagem.CaminhoImagem4 != null)
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
                Console.WriteLine($"Erro ao excluir montagem: {ex.Message}");

                return false;
            }
        }

        public async Task<bool> Salvar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4, List<string> tag)
        {
            try
            {
                if (arquivo1 != null && arquivo1.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo1.FileName;
                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo1.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem = uniqueFileName;
                }
                if (arquivo2 != null && arquivo2.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo2.FileName;
                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo2.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem2 = uniqueFileName;
                }
                if (arquivo3 != null && arquivo3.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo3.FileName;
                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo3.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem3 = uniqueFileName;
                }
                if (arquivo4 != null && arquivo4.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo4.FileName;
                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo4.CopyTo(fileStream);
                    }
                    montagem.CaminhoImagem4 = uniqueFileName;
                }

                string tags = String.Empty;
                if (tag.Count > 0)
                {
                    foreach (var item in tag)
                    {
                        tags = tags + "," + item;
                    }

                    montagem.Tags = tags.Remove(0, 1);
                }
                else
                {
                    tags = String.Empty;
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

        public async Task<bool> Editar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4, List<string> tag)
        {
            var montagemExistente = await _adminContext.MH_MONTAGEM.FindAsync(montagem.Id);

            if (montagemExistente == null)
            {
                return false;
            }

            _adminContext.Entry<Montagem>(montagemExistente).State = EntityState.Detached;


            montagem.CaminhoImagem = montagemExistente.CaminhoImagem;
            montagem.CaminhoImagem2 = montagemExistente.CaminhoImagem2;
            montagem.CaminhoImagem3 = montagemExistente.CaminhoImagem3;
            montagem.CaminhoImagem4 = montagemExistente.CaminhoImagem4;

            if (montagem.Status1)
            {
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoAntigo);
                File.Delete(filePath);

                montagem.CaminhoImagem = string.Empty;
            }
            if (arquivo1 != null)
            {
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoAntigo);
                File.Delete(filePath);

                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo1.FileName;
                filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoNovo);

                using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    arquivo1.CopyTo(fileStream);
                }

                montagem.CaminhoImagem = nomeArquivoNovo;
            }

            if (arquivo2 != null)
            {
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoAntigo);
                File.Delete(filePath);

                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo2.FileName;
                filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoNovo);

                using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    arquivo2.CopyTo(fileStream);
                }

                montagem.CaminhoImagem2 = nomeArquivoNovo;

            }

            if (arquivo3 != null)
            {
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoAntigo);
                File.Delete(filePath);

                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo3.FileName;
                filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoNovo);

                using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    arquivo3.CopyTo(fileStream);
                }

                montagem.CaminhoImagem3 = nomeArquivoNovo;

            }

            if (arquivo4 != null)
            {
                var nomeArquivoAntigo = montagemExistente.CaminhoImagem;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoAntigo);
                File.Delete(filePath);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo4.FileName;
                filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/montagem/", nomeArquivoNovo);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo4.CopyTo(fileStream);
                }

                montagem.CaminhoImagem4 = nomeArquivoNovo;

            }

            string tags = String.Empty;
            if (tag.Count > 0)
            {
                foreach (var item in tag)
                {
                    tags = tags + "," + item;
                }

                montagem.Tags = tags.Remove(0, 1);
            }
            else
            {
                tags = String.Empty;
            }

            _adminContext.Entry(montagem).State = EntityState.Modified;

            await _adminContext.SaveChangesAsync();

            return true;
        }

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/montagem/";
        }
    }
}
