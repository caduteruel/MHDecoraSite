using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using MHDecora.Admin.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Application.Services
{
   

    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<bool> Criar(Tag tag)
        {
            return await _tagRepository.Criar(tag);
        }

        public async Task<bool> Editar(Tag tag)
        {
            return await _tagRepository.Editar(tag);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _tagRepository.Excluir(id);
        }

        public async Task<Tag> GetTagById(int id)
        {
            return await _tagRepository.GetTagById(id);
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _tagRepository.GetTags();
        }
    }
}
