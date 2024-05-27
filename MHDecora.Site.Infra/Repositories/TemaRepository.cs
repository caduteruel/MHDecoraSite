using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public TemaRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Tema>> Buscar()
        {
            //List<Tema> listaTema =
            //[
            //    new Tema()
            //    {
            //        Id = 1,
            //        CaminhoImagem = "/image/img1.jpg",
            //        Texto = "Barbie"
            //    },
            //    new Tema()
            //    {
            //        Id = 2,
            //        CaminhoImagem = "/image/img2.jpg",
            //        Texto = "Patrulha Caninna"
            //    },
            //    new Tema()
            //    {
            //        Id = 3,
            //        CaminhoImagem = "/image/img3.jpg",
            //        Texto = "A Pequena Sereia"
            //    },
            //    new Tema()
            //    {
            //        Id = 4,
            //        CaminhoImagem = "/image/img1.jpg",
            //        Texto = "Futebol"
            //    },
            //    new Tema()
            //    {
            //        Id = 5,
            //        CaminhoImagem = "/image/img2.jpg",
            //        Texto = "Princesas"
            //    },
            //    new Tema()
            //    {
            //        Id = 6,
            //        CaminhoImagem = "/image/img3.jpg",
            //        Texto = "A Pequena Sereia"
            //    },
            //];
            // return await _context.Banners.ToListAsync();

            List<Tema> listaTemas = await _context.MH_TEMA.ToListAsync();

            foreach (var item in listaTemas)
            {
                item.CaminhoImagem = GetTemaPath() + item.CaminhoImagem;
            }

            return listaTemas;
        }

        private string GetTemaPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
