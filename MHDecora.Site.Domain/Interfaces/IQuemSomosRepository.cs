using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IQuemSomosRepository
    {
        Task<QuemSomos> Buscar();
    }
}
