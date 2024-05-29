using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> GetContatoById(int id);
        Task<bool> Criar(Contato contato);
        Task<bool> Editar(Contato contato);
        Task<bool> Excluir(int contatoId);
    }
}
