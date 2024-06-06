using MHDecora.Admin.Domain.Entities;

namespace MHDecora.Admin.Domain.Interfaces.CrossCutting
{
    public interface IOrcamentoCC
    {
        Task<bool> Salvar(Orcamento orcamento);
    }
}
