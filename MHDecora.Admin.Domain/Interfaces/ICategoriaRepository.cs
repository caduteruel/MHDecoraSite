using MHDecora.Admin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetCategoriaById(int id);
        Task<List<Categoria>> GetCategorias();
        Task Criar(Categoria categoria);
        Task<bool> Editar(Categoria categoria);
        Task<bool> Excluir(int id);
    }
}
