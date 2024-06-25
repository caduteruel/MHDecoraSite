using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Admin.Infra.Repositories
{
    public class MidiaSocialRepository : IMidiaSocialRepository
    {
        public readonly AdminContext _adminContext;

        public MidiaSocialRepository(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public async Task<bool> Criar(MidiaSocial midiaSocial)
        {
            try
            {
                _adminContext.MH_CONTATO.Add(midiaSocial);
                
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

        public async Task<bool> Editar(MidiaSocial midiaSocial)
        {
            var contatoExistente = await _adminContext.MH_CONTATO.FindAsync(midiaSocial.Id);

            if (contatoExistente == null)
            {
                return false;
            }

            _adminContext.Entry(contatoExistente).CurrentValues.SetValues(midiaSocial);

            await _adminContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Excluir(int midiaSocialId)
        {
            try
            {
                var contato = new Contato { Id = midiaSocialId };

                _adminContext.Entry(contato).State = EntityState.Deleted;

                await _adminContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<MidiaSocial> Consultar()
        {
            return await _adminContext.MH_CONTATO.ToListAsync();
        }
    }
}
