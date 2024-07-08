using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IMontagemRepository
    {
        Task<List<Montagem>> Buscar();
        Task<List<Montagem>> BuscarDestaque();
        Task<List<Montagem>> BuscarPorCategoria(int categoriaId);

        Task<List<Montagem>> BuscarPorTagsTema(int temaId);
        
        Task<List<Montagem>> Pesquisa(string texto);

        Task<Detalhe> BuscarPorId(int montagemId);
        Task<List<Montagem>> BuscarPorFiltro(int categoriaId, string filter);
    }
}
