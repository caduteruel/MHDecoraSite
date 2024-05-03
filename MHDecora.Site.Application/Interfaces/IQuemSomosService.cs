using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application.Interfaces
{
    public interface IQuemSomosService
    {
        Task<QuemSomos> Buscar();
    }
}
