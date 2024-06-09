using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Domain.Mappers
{
    public static class BannerMapper
    {
        public static MHDecora.Site.Domain.Entities.Banner ToSiteModel(this MHDecora.Admin.Domain.Entities.Banner adminBanner)
        {
            if (adminBanner == null) return null;

            return new MHDecora.Site.Domain.Entities.Banner
            {
                Id = adminBanner.Id,
                Descricao = adminBanner.Descricao,
                Ordem = adminBanner.Ordem,
                CaminhoImagem = adminBanner.CaminhoImagem
            };
        }

        public static List<MHDecora.Site.Domain.Entities.Banner> ToSiteModel(this List<MHDecora.Admin.Domain.Entities.Banner> adminBanners)
        {
            if (adminBanners == null || !adminBanners.Any()) return new List<MHDecora.Site.Domain.Entities.Banner>();

            return adminBanners.Select(adminBanner => adminBanner.ToSiteModel()).ToList();
        }
    }
}
