using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Criar(Banner banner, IFormFile imagem)
        {
            await _bannerRepository.Criar(banner, imagem);
        }

        public Task<Banner> GetBannerById(int id)
        {
            return _bannerRepository.GetById(id);
        }

        public async Task <List<Banner>> GetBanners()
        {
            return await _bannerRepository.GetBanners();
        }

        
    }
}
