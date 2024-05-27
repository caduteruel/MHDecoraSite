using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> Buscar();
    }
}
