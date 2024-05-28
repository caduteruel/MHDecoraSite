using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Admin.Infra.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly AdminContext _context;
        private readonly IConfiguration _configuration;

        public TemaRepository(AdminContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

            //List<Tema> listaTemas = await _context.MH_TEMA.ToListAsync();

            //foreach (var item in listaTemas)
            //{
            //    item.CaminhoImagem = GetTemaPath() + item.CaminhoImagem;
            //}

            return listaTema;
        }

        private string GetTemaPath()
        {
            return _configuration["ImagePath:Tema"];
        }
    }
}
