﻿using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;

namespace MHDecora.Site.Application
{
    public class MontagemService : IMontagemService
    {
        private readonly IMontagemRepository _montagemRepository;

        public MontagemService(IMontagemRepository montagemRepository)
        {
            _montagemRepository = montagemRepository;
        }

        public async Task<List<Montagem>> Buscar()
        {
            return await _montagemRepository.Buscar();
        }

        public async Task<List<Montagem>> BuscarDestaque()
        {
            return await _montagemRepository.BuscarDestaque();
        }

        public async Task<List<Montagem>> BuscarPorCategoria(int categoriaId)
        {
            return await _montagemRepository.BuscarPorCategoria(categoriaId);
        }

        public async Task<Montagem> BuscarPorId(int montagemId)
        {
            return await _montagemRepository.BuscarPorId(montagemId);
        }
    }
}
