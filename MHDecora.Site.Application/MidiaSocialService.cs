using MHDecora.Site.Domain.Interfaces;
using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application
{
    
    public class MidiaSocialService : IMidiaSocialService
    {
        private readonly IMidiaSocialRepository _midiaSocialRepository;

        public MidiaSocialService(IMidiaSocialRepository midiaSocialRepository)
        {
            _midiaSocialRepository = midiaSocialRepository;
        }

        public async Task<MidiaSocial> GetMidiaSocial()
        {
            return await _midiaSocialRepository.GetMidiaSocial();
        }
    }
}
