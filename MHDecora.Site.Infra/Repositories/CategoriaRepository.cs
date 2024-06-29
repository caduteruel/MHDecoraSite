using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Categoria>> Buscar()
        {
            var listaCategorias = await _context.MH_CATEGORIAS.ToListAsync();

            return listaCategorias;
        }
    }
}
