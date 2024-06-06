using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IMontagemService
    {
        Task<List<Montagem>> Buscar();
        Task<bool> Excluir(int montagemId);
        Task<Montagem> GetById(int montagemId);
        Task<bool> Salvar(Montagem montagem, IFormFile imagem1, IFormFile imagem2, IFormFile imagem3, IFormFile imagem4, List<string> tag);
        Task<bool> Editar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4, List<string> tag);
    }
}
