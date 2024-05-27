using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Application.Services
{
    
    public class QuemSomosService : IQuemSomosService
    {
        private readonly IQuemSomosRepository _quemSomosRepository;

        public QuemSomosService(IQuemSomosRepository quemSomosRepository)
        {
            _quemSomosRepository = quemSomosRepository;
        }

        public async Task<bool> Editar(QuemSomos dados, IFormFile imagem)
        {
            return await _quemSomosRepository.Editar(dados, imagem);
        }

        public async Task Salvar(QuemSomos dados, IFormFile imagem)
        {
            await _quemSomosRepository.Salvar(dados, imagem);
        }
    }
}
