using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface ITemaService
    {
        Task<List<Tema>> Buscar();
    }
}
