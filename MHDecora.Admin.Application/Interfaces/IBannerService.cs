using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IBannerService
    {
        Task<Banner> GetBannerById(int id);
        Task<List<Banner>> GetBanners();
        Task Criar(Banner banner, IFormFile imagem);
        Task<bool> Editar(IFormFile arquivo, Banner banner);
        Task<bool> Excluir(int bannerId);
    }
}
