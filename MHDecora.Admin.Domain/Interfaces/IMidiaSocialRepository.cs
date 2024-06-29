﻿using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface IMidiaSocialRepository
    {
        Task<MidiaSocial> Consultar();
        Task<bool> Criar(MidiaSocial midiaSocial);
        Task<MidiaSocial> GetById(int midiaSocialId);
        Task<bool> Editar(MidiaSocial midiaSocial);
        Task<bool> Excluir(int midiaSocialId);
    }
}