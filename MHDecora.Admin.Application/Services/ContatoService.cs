using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;

namespace MHDecora.Admin.Application.Services
{
    public class ContatoService : IOrcamentoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<bool> Criar(Contato contato)
        {
            return await _contatoRepository.Criar(contato);
        }

        public async Task<bool> Editar(Contato contato)
        {
            return await _contatoRepository.Editar(contato);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _contatoRepository.Excluir(id);
        }

        public async Task<List<Contato>> GetContato()
        {
            return await _contatoRepository.GetContato();
        }

        public async Task<Contato> GetContatoById(int id)
        {
            return await _contatoRepository.GetContatoById(id);
        }
    }
}
