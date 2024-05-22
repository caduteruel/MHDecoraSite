using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface IBannerRepository
    {
        Task<Banner> GetById(int id);
        Task<List<Banner>> GetBanners();
        Task Criar(Banner banner, IFormFile imagem);
        Task Excluir(int bannerId);
    }
}
