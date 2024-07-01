using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace MHDecora.Admin.Infra.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly AdminContext _context;
        private readonly IConfiguration _configuration;

        public TemaRepository(AdminContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Tema>> Buscar()
        {
            List<Tema> listaTemas = await _context.MH_TEMA.ToListAsync();

            foreach (var item in listaTemas)
            {
                item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;                
            }

            return listaTemas;
        }

        public async Task<Tema> BuscarPorId(int id)
        {
           Tema tema = await _context.MH_TEMA.FindAsync(id);

            tema.CaminhoImagem = GetPathImagens() + tema.CaminhoImagem;

            if (tema.Tags != null)
            {
                var listaTags = tema.Tags.Split(",");
                tema.TagsList = new List<Tag>();

                foreach (var tag in listaTags)
                {
                    var tag2 = _context.MH_TAGS.Where(x => x.Id.Equals(tag)).FirstOrDefault();
                    tema.TagsList.Add(tag2);
                }
            }            

            return tema;
        }

        public async Task<bool> Salvar(Tema tema, IFormFile arquivo, List<string> tag)
        {
            try
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/tema/", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo.CopyTo(fileStream);
                    }
                    tema.CaminhoImagem = uniqueFileName;
                }

                string tags = String.Empty;
                if (tag.Count > 0)
                {
                    foreach (var item in tag)
                    {
                        tags = tags + "," + item;
                    }

                    tema.Tags = tags.Remove(0, 1);
                }
                else
                {
                    tags = String.Empty;
                }

                _context.MH_TEMA.Add(tema);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _context.DisposeAsync();
            }
        }

        public async Task<bool> Excluir(int temaId)
        {
            try
            {
                // Obtém o caminho completo da imagem do banner pelo ID
                string imagePath = await _context.MH_TEMA
                                                                .Where(b => b.Id == temaId)
                                                                .Select(b => b.CaminhoImagem)
                                                                .FirstOrDefaultAsync();

                if (imagePath != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath);

                    // Exclui o registro do tema
                    var tema = new Tema { Id = temaId };
                    _context.Entry(tema).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();

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
                Console.WriteLine($"Erro ao excluir tema: {ex.Message}");
                return false;
            }


        }

        public async Task<bool> Editar(IFormFile arquivo, Tema tema, List<string> tag)
        {
            var temaExistente = await _context.MH_TEMA.FindAsync(tema.Id);


            if (temaExistente == null)
            {
                return false;
            }

            _context.Entry<Tema>(temaExistente).State = EntityState.Detached;

            if (!tema.Status1) tema.CaminhoImagem = temaExistente.CaminhoImagem;

            if (tema.Status1)
            {
                DeleteFile(Path.Combine("/var/aspnetcore/mhdecora_imagens/tema/", temaExistente.CaminhoImagem));
                if (arquivo != null)
                {
                    tema.CaminhoImagem = SaveFile(arquivo);
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
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/tema/", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo.CopyTo(fileStream);
                }

                tema.CaminhoImagem = uniqueFileName;

                return uniqueFileName;
            }

            //tema.CaminhoImagem = temaExistente.CaminhoImagem;

            //if (arquivo != null)
            //{
            //   // var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "tema");
            //    var nomeArquivoAntigo = temaExistente.CaminhoImagem;
            //    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/tema/", nomeArquivoAntigo);
            //    File.Delete(filePath);

            //    var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
            //    filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/tema/", nomeArquivoNovo);

            //    using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
            //    {
            //        arquivo.CopyTo(fileStream);
            //    }

            //    tema.CaminhoImagem = nomeArquivoNovo;

            //}

            string tags = String.Empty;
            if (tag.Count > 0)
            {
                foreach (var item in tag)
                {
                    tags = tags + "," + item;
                }

                tema.Tags = tags.Remove(0, 1);
            }
            else
            {
                tags = String.Empty;
            }

            _context.Entry(tema).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/tema/";
        }
    }
}
