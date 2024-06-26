using MHDecora.Site.Domain.Entities;

namespace MHDecora.Site.Application.Interfaces
{
    public interface IMidiaSocialService
    {
       Task<MidiaSocial>GetMidiaSocial();
    }
}
