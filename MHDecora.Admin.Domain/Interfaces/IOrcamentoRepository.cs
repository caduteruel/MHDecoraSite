using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface IOrcamentoRepository
    {
        Task<bool> Salvar(Orcamento orcamento);
    }
}
