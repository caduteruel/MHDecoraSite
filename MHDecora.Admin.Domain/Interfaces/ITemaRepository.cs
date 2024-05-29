using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface ITemaRepository
    {
        Task<List<Tema>> Buscar();
        Task<Tema> BuscarPorId(int id);
        Task<bool> Salvar(Tema tema, IFormFile arquivo);
        Task<bool> Excluir(int temaId);
        Task<bool> Editar(IFormFile arquivo, Tema tema);
    }
}
