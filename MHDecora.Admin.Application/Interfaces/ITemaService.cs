using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface ITemaService
    {
        Task<List<Tema>> Buscar();
        Task<Tema> BuscarPorId(int id);
        Task<bool> Salvar(Tema tema, IFormFile arquivo, List<string> tag);
        Task<bool> Excluir(int temaId);
        Task<bool> Editar(IFormFile arquivo, Tema tema, List<string> tag);
    }
}
