using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application.Interfaces
{
    public interface IGaleriaDestaqueService
    {
        Task<List<GaleriaDestaque>> Buscar();
    }
}
