using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;

namespace MHDecora.Site.Application
{
    public class InstagramService : IInstagramService
    {
        private readonly IInstagramRepository _instagramRepository;

        public InstagramService(IInstagramRepository instagramRepository)
        {
            _instagramRepository = instagramRepository;
        }

        public async Task<dynamic> GetRecentsPosts()
        {
            return await _instagramRepository.GetRecentsPosts();
        }
    }
}
