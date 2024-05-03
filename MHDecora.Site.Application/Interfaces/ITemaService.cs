using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application.Interfaces
{
    public interface ITemaService
    {
        Task<List<Tema>> Buscar();
    }
}
