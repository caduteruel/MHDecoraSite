using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces.CrossCutting;

namespace MHDecora.Admin.Application.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoCC _orcamentoRepository;

        public OrcamentoService(IOrcamentoCC orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        public async Task<bool> Salvar(Orcamento orcamento)
        {
            return await _orcamentoRepository.Salvar(orcamento);
        }
    }
}
