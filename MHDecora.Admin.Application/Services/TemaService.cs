using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MHDecora.Admin.Application
{
    public class TemaService : ITemaService
    {
        private readonly ITemaRepository _temaRepository;

        public TemaService(ITemaRepository temaRepository)
        {
            _temaRepository = temaRepository;
        }

        public async Task<List<Tema>> Buscar()
        {
            return await _temaRepository.Buscar();
        }
        public async Task<Tema> BuscarPorId(int id)
        {
            return await _temaRepository.BuscarPorId(id);
        }
        public async Task<bool> Salvar(Tema tema, IFormFile arquivo, List<string> tag)
        {
            return await _temaRepository.Salvar(tema, arquivo, tag);
        }

        public async Task<bool> Editar(IFormFile arquivo, Tema tema, List<string> tag)
        {
            return await _temaRepository.Editar(arquivo, tema, tag);
        }

        public async Task<bool> Excluir(int temaId)
        {
            return await _temaRepository.Excluir(temaId);
        }
    }
}
