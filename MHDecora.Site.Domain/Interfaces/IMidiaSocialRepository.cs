using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IMidiaSocialRepository
    {
        Task<MidiaSocial> GetMidiaSocial();
    }
}
