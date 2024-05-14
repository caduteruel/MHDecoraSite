using MHDecora.Admin.Domain.Entities;
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
    }
}
