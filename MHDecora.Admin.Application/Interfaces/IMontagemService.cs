using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IMontagemService
    {
        Task<List<Montagem>> Buscar();
        Task<bool> Excluir(int montagemId);
        Task<Montagem> GetById(int montagemId);
        Task<bool> Salvar(Montagem montagem, IFormFile imagem);
    }
}
