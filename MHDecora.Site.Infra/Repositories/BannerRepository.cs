using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Site.Infra.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly SiteContext _context;

        public TemaRepository(SiteContext context)
        {
            _context = context;
        }

        public async Task<List<Tema>> Buscar()
        {
            List<Tema> listaTema =
            [
                new Tema()
                {
                    Id = 1,
                    CaminhoImagem = "/image/img1.jpg",
                    Texto = "Barbie"
                },
                new Tema()
                {
                    Id = 2,
                    CaminhoImagem = "/image/img2.jpg",
                    Texto = "Patrulha Caninna"
                },
                new Tema()
                {
                    Id = 3,
                    CaminhoImagem = "/image/img3.jpg",
                    Texto = "A Pequena Sereia"
                },
                new Tema()
                {
                    Id = 4,
                    CaminhoImagem = "/image/img1.jpg",
                    Texto = "Futebol"
                },
                new Tema()
                {
                    Id = 5,
                    CaminhoImagem = "/image/img2.jpg",
                    Texto = "Princesas"
                },
                new Tema()
                {
                    Id = 6,
                    CaminhoImagem = "/image/img3.jpg",
                    Texto = "A Pequena Sereia"
                },
            ];
           // return await _context.Banners.ToListAsync();

            return listaTema;
        }
    }
}
