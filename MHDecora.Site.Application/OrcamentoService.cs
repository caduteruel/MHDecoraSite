using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Application
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;
        public OrcamentoService(IOrcamentoRepository orcamentoRepository) 
        { 
            _orcamentoRepository = orcamentoRepository;
        }
        public async Task<bool> EnviarOrcamento(Orcamento orcamento)
        {
            return await _orcamentoRepository.EnviarOrcamento(orcamento);
        }
    }
}
