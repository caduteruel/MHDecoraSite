using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MHDecora.Admin.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task Criar(Categoria categoria)
        {
            await _categoriaRepository.Criar(categoria);
        }

        public async Task<bool> Editar(Categoria categoria)
        {
            return await _categoriaRepository.Editar(categoria);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _categoriaRepository.Excluir(id);
        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            return await _categoriaRepository.GetCategoriaById(id);
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await _categoriaRepository.GetCategorias();
        }
    }
}
