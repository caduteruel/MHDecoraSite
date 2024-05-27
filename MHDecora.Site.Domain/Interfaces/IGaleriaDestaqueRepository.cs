using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IGaleriaDestaqueRepository
    {
        Task<List<GaleriaDestaque>> Buscar();
    }
}
