using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface IMontagemRepository
    {
        Task<List<Montagem>> Buscar();
        Task<bool> Excluir(int montagemId);
        Task<bool> Salvar(Montagem montagem, IFormFile imagem);

    }
}
