namespace MHDecora.Site.Domain.Interfaces
{
    public interface IInstagramRepository
    {
        Task<dynamic> GetRecentsPosts();
    }
}
