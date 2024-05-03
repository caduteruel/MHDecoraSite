namespace MHDecora.Site.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> BuscarTodos();
        Task<T> BuscarPorId(int id);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Apagar(int id);
    }
}
