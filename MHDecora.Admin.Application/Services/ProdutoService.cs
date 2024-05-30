using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Criar(Produto produto, IFormFile arquivo0, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3)
        {
            return await _produtoRepository.Criar(produto, arquivo0, arquivo1, arquivo2, arquivo3);
        }

        public async Task<bool> Editar(Produto produto, IFormFile arquivo0, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3)
        {
            return await _produtoRepository.Editar(produto, arquivo0, arquivo1, arquivo2, arquivo3);
        }

        public async Task<bool> Excluir(int produtoId)
        {
            return await _produtoRepository.Excluir(produtoId);
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _produtoRepository.GetProdutoById(id);
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _produtoRepository.GetProdutos();
        }
    }
}
