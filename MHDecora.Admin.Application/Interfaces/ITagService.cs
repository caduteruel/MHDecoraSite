using MHDecora.Admin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface ITagService
    {
        Task<Tag> GetTagById(int id);
        Task<List<Tag>> GetTags();
        Task Criar(Tag tag);
        Task<bool> Editar(Tag tag);
        Task<bool> Excluir(int id);
    }
}
