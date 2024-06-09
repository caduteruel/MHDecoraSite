using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Domain.Mappers
{
    public static class QuemSomosMapper
    {
        public static MHDecora.Site.Domain.Entities.QuemSomos ToSiteModel(this MHDecora.Admin.Domain.Entities.QuemSomos adminQuemSomos)
        {
            if (adminQuemSomos == null) return null;

            return new MHDecora.Site.Domain.Entities.QuemSomos
            {
                Id = adminQuemSomos.Id,
                Titulo = adminQuemSomos.Titulo,
                CaminhoImagem = adminQuemSomos.CaminhoImagem
            };
        }
    }
}
