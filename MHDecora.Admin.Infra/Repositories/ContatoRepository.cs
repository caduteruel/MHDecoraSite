using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Admin.Infra.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        public readonly AdminContext _adminContext;

        public ContatoRepository(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public async Task<bool> Criar(Contato contato)
        {
            try
            {
                _adminContext.MH_CONTATO.Add(contato);
                
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

        public async Task<bool> Editar(Contato contato)
        {
            var contatoExistente = await _adminContext.MH_CONTATO.FindAsync(contato.Id);

            if (contatoExistente == null)
            {
                return false;
            }

            _adminContext.Entry(contatoExistente).CurrentValues.SetValues(contato);

            await _adminContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var contato = new Contato { Id = id };

                _adminContext.Entry(contato).State = EntityState.Deleted;

                await _adminContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Contato>> GetContato()
        {
            return await _adminContext.MH_CONTATO.OrderByDescending(x => x.Id).Take(1).ToListAsync();
        }
        public async Task<Contato> GetContatoById(int id)
        {
            return await _adminContext.MH_CONTATO.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
