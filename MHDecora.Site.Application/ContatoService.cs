using MHDecora.Site.Domain.Interfaces;
using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Application
{
    
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<Contato> GetContato()
        {
            return await _contatoRepository.Buscar();
        }
    }
}
