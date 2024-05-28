using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface ITemaRepository
    {
        Task<List<Tema>> Buscar();
    }
}
