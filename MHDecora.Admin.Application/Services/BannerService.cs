using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;

namespace MHDecora.Admin.Application.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }


        public Task<Banner> GetBannerById(int id)
        {
            return _bannerRepository.GetById(id);
        }
    }
}
