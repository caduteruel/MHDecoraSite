using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repository
{
    public class GaleriaDestaqueRepository : IGaleriaDestaqueRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public GaleriaDestaqueRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<GaleriaDestaque>> Buscar()
        {
            //List<GaleriaDestaque> listaGaleriaDestaque = await _context.MH_GALERIADESTAQUE.ToListAsync();
            List<GaleriaDestaque> listaGaleriaDestaque = new List<GaleriaDestaque>();

            foreach (var item in listaGaleriaDestaque)
            {
                item.CaminhoImagem = GetTemaPath() + item.CaminhoImagem;
            }

            return listaGaleriaDestaque;
        }

        private string GetTemaPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
