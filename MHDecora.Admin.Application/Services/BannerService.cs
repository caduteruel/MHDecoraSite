using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<bool> Excluir(int bannerId)
        {
           return await _bannerRepository.Excluir(bannerId);
        }
        public async Task<bool> Editar(IFormFile arquivo, Banner banner)
        {
            return await _bannerRepository.Editar(arquivo, banner);
        }
    }
}
