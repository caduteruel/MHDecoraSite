using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AdminContext _adminContext;

        public CategoriaRepository(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public async Task<bool> Criar(Categoria categoria)
        {
            try
            {
                _adminContext.MH_CATEGORIAS.Add(categoria);
                
                await _adminContext.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                await _adminContext.DisposeAsync();
            }
        }

        public async Task<bool> Editar(Categoria categoria)
        {
            var categoriaExistente = await _adminContext.MH_CATEGORIAS.FindAsync(categoria.Id);

            if (categoriaExistente == null)
            {
                return false;
            }

            _adminContext.Entry(categoriaExistente).CurrentValues.SetValues(categoria);

            await _adminContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var categoria = new Categoria { Id = id };
                _adminContext.Entry(categoria).State = EntityState.Deleted;
                await _adminContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            return await _adminContext.MH_CATEGORIAS.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            try
            {
                return await _adminContext.MH_CATEGORIAS.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _adminContext.DisposeAsync();
            }
        }
    }
}
