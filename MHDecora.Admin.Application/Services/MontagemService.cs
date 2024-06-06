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

        public async Task<bool> Salvar(Montagem montagem, IFormFile imagem1, IFormFile imagem2, IFormFile imagem3, IFormFile imagem4, List<string> tag)
        {
            return await _montagemRepository.Salvar(montagem, imagem1, imagem2, imagem3, imagem4, tag);
        }

        public async Task<bool> Excluir(int montagemId)
        {
            return await _montagemRepository.Excluir(montagemId);
        }

        public async Task<Montagem> GetById(int montagemId)
        {
            return await _montagemRepository.GetById(montagemId);
        }

        public async Task<bool> Editar(Montagem montagem, IFormFile arquivo1, IFormFile arquivo2, IFormFile arquivo3, IFormFile arquivo4, List<string> tag)
        {
            return await _montagemRepository.Editar(montagem, arquivo1, arquivo2, arquivo3, arquivo4, tag);
        }
    }
}
