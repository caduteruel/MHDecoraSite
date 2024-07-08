using MHDecora.Site.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MHDecora.Site.Application.Interfaces
{
    public interface IMontagemService
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
