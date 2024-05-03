using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IBannerRepository
    {
        Task<List<Banner>> BuscarTodos();
    }
}
