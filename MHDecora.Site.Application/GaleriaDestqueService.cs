using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;

namespace MHDecora.Site.Application
{
    public class GaleriaDestaqueService : IGaleriaDestaqueService
    {
        private readonly IGaleriaDestaqueRepository _galeriaDestaqueRepository;

        public GaleriaDestaqueService(IGaleriaDestaqueRepository galeriaDestaqueRepository)
        {
            _galeriaDestaqueRepository = galeriaDestaqueRepository;
        }

        public async Task<List<GaleriaDestaque>> Buscar()
        {
            return await _galeriaDestaqueRepository.Buscar();
        }
    }
}
