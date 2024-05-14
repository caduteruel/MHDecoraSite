using MHDecora.Admin.Domain.Entities;
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
    }
}
