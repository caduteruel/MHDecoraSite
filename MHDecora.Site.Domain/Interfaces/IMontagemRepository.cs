using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IMontagemRepository
    {
        Task<List<Montagem>> Buscar();
        Task<List<Montagem>> BuscarDestaque();
        Task<List<Montagem>> BuscarPorCategoria(int categoriaId);
        Task<Montagem> BuscarPorId(int montagemId);
    }
}
