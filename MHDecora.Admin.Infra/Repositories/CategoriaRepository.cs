using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AdminContext _adminContext;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(AdminContext adminContext, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _configuration = configuration;
        }
        public async Task<bool> Criar(Categoria categoria, IFormFile imagem)
        {
            try
            {
                if (imagem != null && imagem.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;

                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/categoria/", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                    {
                        imagem.CopyTo(fileStream);
                    }

                    categoria.CaminhoImagem = uniqueFileName;
                }

                _adminContext.MH_CATEGORIAS.Add(categoria);
                
                await _adminContext.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                await _adminContext.DisposeAsync();
            }
        }

        public async Task<bool> Editar(Categoria categoria, IFormFile imagem)
        {
            var categoriaExistente = await _adminContext.MH_CATEGORIAS.FindAsync(categoria.Id);

            if (categoriaExistente == null)
            {
                return false;
            }

            _adminContext.Entry<Categoria>(categoriaExistente).State = EntityState.Detached;

            categoria.CaminhoImagem = categoriaExistente.CaminhoImagem;

            if (categoriaExistente != null)
            {
                DeleteFile(Path.Combine("/var/aspnetcore/mhdecora_imagens/categoria/", categoriaExistente.CaminhoImagem));
                if (imagem != null)
                {
                    SaveFile(imagem);
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
            void SaveFile(IFormFile arquivo)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/categoria/", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo.CopyTo(fileStream);
                }

                categoria.CaminhoImagem = uniqueFileName;
            }

            //if (imagem != null)
            //{
            //    var nomeArquivoAntigo = categoriaExistente.CaminhoImagem;

            //    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/categoria/", nomeArquivoAntigo);

            //    File.Delete(filePath);

            //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;

            //    filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/categoria/", uniqueFileName);


            //    using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
            //    {
            //        imagem.CopyTo(fileStream);
            //    }

            //    categoria.CaminhoImagem = uniqueFileName;
            //}

            _adminContext.Entry(categoria).State = EntityState.Modified;
            await _adminContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                // Obtém o caminho completo da imagem do banner pelo ID
                string imagePath = await _adminContext.MH_CATEGORIAS
                                                                .Where(b => b.Id == id)
                                                                .Select(b => b.CaminhoImagem)
                                                                .FirstOrDefaultAsync();

                if (imagePath != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath);

                    // Exclui o registro do banner
                    var categoria = new Categoria { Id = id };
                    _adminContext.Entry(categoria).State = EntityState.Deleted;
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
                Console.WriteLine($"Erro ao excluir categoria: {ex.Message}");
                return false;
            }

        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            Categoria imagem = await _adminContext.MH_CATEGORIAS.FirstOrDefaultAsync(x => x.Id == id);

            imagem.CaminhoImagem = GetPathImagens() + imagem.CaminhoImagem;

            return imagem;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            try
            {
                List<Categoria> imagens =  await _adminContext.MH_CATEGORIAS.ToListAsync();

                foreach(var item in imagens)
                {
                    item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;
                }

                return imagens;
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/categoria/";
        }
    }
}
