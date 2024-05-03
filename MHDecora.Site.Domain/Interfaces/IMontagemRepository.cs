using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IMontagemRepository
    {
        Task<List<Montagem>> Buscar();
    }
}
