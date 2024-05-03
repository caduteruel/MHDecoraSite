using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SiteContext _context;

        public BaseRepository(SiteContext context)
        {
            _context = context;
        }

        public async Task<List<T>> BuscarTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Apagar(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
