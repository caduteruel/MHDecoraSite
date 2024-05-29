using MHDecora.Admin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> GetTagById(int id);
        Task<List<Tag>> GetTags();
        Task<bool> Criar(Tag tag);
        Task<bool> Editar(Tag tag);
        Task<bool> Excluir(int id);
    }
}
