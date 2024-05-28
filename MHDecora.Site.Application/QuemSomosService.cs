using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;

namespace MHDecora.Site.Application
{
    public class QuemSomosService : IQuemSomosService
    {
        private readonly IQuemSomosRepository _quemSomosRepository;

        public QuemSomosService(IQuemSomosRepository quemSomosRepository)
        {
            _quemSomosRepository = quemSomosRepository;
        }

        public async Task<QuemSomos> Buscar()
        {
            return await _quemSomosRepository.Buscar();
        }
    }
}
