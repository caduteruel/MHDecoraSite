using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application
{
    public class MonstagemService : IMontagemService
    {
        private readonly IMontagemRepository _montagemRepository;

        public MonstagemService(IMontagemRepository montagemRepository)
        {
            _montagemRepository = montagemRepository;
        }

        public async Task<List<Montagem>> Buscar()
        {
            return await _montagemRepository.Buscar();
        }

        public async Task<bool> Salvar(Montagem montagem, IFormFile arquivo)
        {
            return await _montagemRepository.Salvar(montagem, arquivo);
        }

        public async Task<bool> Excluir(int montagemId)
        {
            return await _montagemRepository.Excluir(montagemId);
        }

        public async Task<Montagem> GetById(int montagemId)
        {
            return await _montagemRepository.GetById(montagemId);
        }
    }
}
