using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;

namespace MHDecora.Admin.Application.Services
{
    public class MidiaSocialService : IMidiaSocialService
    {
        private readonly IMidiaSocialRepository _midiaSocialRepository;

        public MidiaSocialService(IMidiaSocialRepository midiaSocialRepository)
        {
            _midiaSocialRepository = midiaSocialRepository;
        }

        public async Task<MidiaSocial> Consultar()
        {
            return await _midiaSocialRepository.Consultar();
        }

        public async Task<bool> Criar(MidiaSocial midiaSocial)
        {
            return await _midiaSocialRepository.Criar(midiaSocial);
        }

        public async Task<bool> Editar(MidiaSocial midiaSocial)
        {
            return await _midiaSocialRepository.Editar(midiaSocial);
        }

        public async Task<bool> Excluir(int midiaSocialId)
        {
            return await _midiaSocialRepository.Excluir(midiaSocialId);
        }
    }
}
