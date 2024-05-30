using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> GetProdutoById(int id);
        Task<List<Produto>> GetProdutos();
        Task<bool> Criar(Produto produto, IFormFile arquivo0, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3);
        Task<bool> Editar(Produto produto, IFormFile arquivo0, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3);
        Task<bool> Excluir(int produtoId);
    }
}