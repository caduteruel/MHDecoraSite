using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IContatoService
    {
        Task<Contato> GetContatoById(int id);
        Task<bool> Criar(Contato contato);
        Task<bool> Editar(Contato contato);
        Task<bool> Excluir(int contatoId);
    }
}
