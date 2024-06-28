using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<Categoria> GetCategoriaById(int id);
        Task<List<Categoria>> GetCategorias();
        Task<bool> Criar(Categoria categoria, IFormFile imagem);
        Task<bool> Editar(Categoria categoria, IFormFile imagem);
        Task<bool> Excluir(int id);
    }
}
