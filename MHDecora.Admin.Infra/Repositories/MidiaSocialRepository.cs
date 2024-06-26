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
                _adminContext.MH_MIDIASOCIAL.Add(midiaSocial);
                
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
            var contatoExistente = await _adminContext.MH_MIDIASOCIAL.FindAsync(midiaSocial.Id);

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
                var midiaSocial = new MidiaSocial { Id = midiaSocialId };

                _adminContext.Entry(midiaSocial).State = EntityState.Deleted;

                await _adminContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<MidiaSocial> GetById(int midiaSocialId)
        {
            return await _adminContext.MH_MIDIASOCIAL.FirstOrDefaultAsync(x => x.Id == midiaSocialId);
        }

        public async Task<MidiaSocial> Consultar()
        {
            return await _adminContext.MH_MIDIASOCIAL.SingleOrDefaultAsync();
        }
    }
}
