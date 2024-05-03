using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application.Interfaces
{
    public interface IBannerService
    {
        Task<List<Banner>> BuscarTodos();
    }
}
