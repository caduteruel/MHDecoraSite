using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IOrcamentoService
    {
        Task<bool> Salvar(Orcamento orcamento);
    }
}
