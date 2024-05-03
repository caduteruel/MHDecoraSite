using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface ITemaRepository
    {
        Task<List<Tema>> Buscar();
    }
}
