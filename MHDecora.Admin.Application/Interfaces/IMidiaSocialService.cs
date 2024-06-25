using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IMidiaSocialService
    {
        Task<MidiaSocial> Consultar();
        Task<bool> Criar(MidiaSocial midiaSocial);
        Task<bool> Editar(MidiaSocial midiaSocial);
        Task<bool> Excluir(int midiaSocialId);
    }
}
