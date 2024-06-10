using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application.Interfaces
{
    public interface IMontagemService
    {
        Task<List<Montagem>> Buscar();
        Task<List<Montagem>> BuscarDestaque();
    }
}
