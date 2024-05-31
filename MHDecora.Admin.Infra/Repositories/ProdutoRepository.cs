﻿using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace MHDecora.Admin.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly AdminContext _adminContext;
        private readonly IConfiguration _configuration;

        public ProdutoRepository(AdminContext adminContext, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _configuration = configuration;
        }

        public async Task<bool> Criar(Produto produto, IFormFile arquivo0, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3)
        {
            try
            {
                // Imagem Maior
                if (arquivo0 != null)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/produto");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo0.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo0.CopyTo(fileStream);
                    }
                    produto.CaminhoImagem[0] = uniqueFileName;
                }
                // Imagem menor
                if (arquivo1 != null)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/produto");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo1.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo1.CopyTo(fileStream);
                    }
                    produto.CaminhoImagem[1] = uniqueFileName;
                }
                // Imagem menor
                if (arquivo2 != null)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/produto");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo2.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo2.CopyTo(fileStream);
                    }
                    produto.CaminhoImagem[2] = uniqueFileName;
                }
                // Imagem menor
                if (arquivo3 != null)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/produto");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo3.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo3.CopyTo(fileStream);
                    }
                    produto.CaminhoImagem[3] = uniqueFileName;
                }

                _adminContext.MH_PRODUTO.Add(produto);

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

        public Task<bool> Editar(Produto produto, IFormFile arquivo0, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(int produtoId)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> GetProdutos()
        {
            throw new NotImplementedException();
        }

        //public async Task <List<Produto>> GetProdutos() 
        //{
        //    var listaProduto = await _adminContext.MH_ProdutoS.ToListAsync();

        //    foreach(var img in listaProduto)
        //    {
        //        img.CaminhoImagem = GetProdutoPath() + img.CaminhoImagem;
        //    }

        //    return listaProduto;
        //}

        //public async Task<Produto> GetById(int id)
        //{
        //    Produto imagem = await _adminContext.MH_ProdutoS.FirstOrDefaultAsync(x => x.Id == id);

        //    imagem.CaminhoImagem = GetProdutoPath() + imagem.CaminhoImagem;

        //    return imagem;
        //}

        //public async Task<bool> Excluir(int ProdutoId)
        //{
        //    try
        //    {
        //        // Obtém o caminho completo da imagem do Produto pelo ID
        //        string imagePath = await _adminContext.MH_ProdutoS
        //                                                        .Where(b => b.Id == ProdutoId)
        //                                                        .Select(b => b.CaminhoImagem)
        //                                                        .FirstOrDefaultAsync();

        //        if (imagePath != null)
        //        {
        //            // Extrai apenas o nome do arquivo da parte final do caminho
        //            string fileName = Path.GetFileName(imagePath);

        //            // Exclui o registro do Produto
        //            var Produto = new Produto { Id = ProdutoId };
        //            _adminContext.Entry(Produto).State = EntityState.Deleted;
        //            await _adminContext.SaveChangesAsync();

        //            // Exclui o arquivo de imagem da pasta wwwroot/Produtos
        //            string imagePathToDelete = Path.Combine("wwwroot", "images\\Produto", fileName);
        //            if (File.Exists(imagePathToDelete))
        //            {
        //                File.Delete(imagePathToDelete);
        //            }

        //            return true;
        //        }
        //        else
        //        {
        //            // Se o caminho da imagem não for encontrado, retorna false indicando que o Produto não foi encontrado
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Em caso de erro, você pode lidar com ele aqui
        //        // Por exemplo, logar o erro ou retornar false
        //        Console.WriteLine($"Erro ao excluir Produto: {ex.Message}");
        //        return false;
        //    }


        //}

        //public async Task<bool> Editar(IFormFile arquivo, Produto Produto)
        //{
        //    var ProdutoExistente = await _adminContext.MH_ProdutoS.FindAsync(Produto.Id);


        //    if (ProdutoExistente == null)
        //    {
        //        return false;
        //    }

        //    Produto.CaminhoImagem = ProdutoExistente.CaminhoImagem;

        //    if (arquivo != null)
        //    {
        //        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Produto");
        //        var nomeArquivoAntigo = ProdutoExistente.CaminhoImagem;
        //        var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
        //        File.Delete(caminhoCompletoAntigo);


        //        var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
        //        var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

        //        using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
        //        {
        //            arquivo.CopyTo(fileStream);
        //        }

        //        Produto.CaminhoImagem = nomeArquivoNovo;

        //    }

        //    _adminContext.Entry(ProdutoExistente).CurrentValues.SetValues(Produto);

        //    //_adminContext.Entry(Produto).State = EntityState.Modified;
        //    await _adminContext.SaveChangesAsync();

        //    return true;
        //}

        private string GetProdutoPath()
        {
            return _configuration["ImagePath:Produto"];
        }
    }
}
