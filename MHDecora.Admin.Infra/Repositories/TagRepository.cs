using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Infra.Repositories
{
    public class TagRepository : ITagRepository
    {
        public readonly AdminContext _adminContext;

        public TagRepository(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public async Task<bool> Criar(Tag tag)
        {
            try
            {
                _adminContext.MH_TAGS.Add(tag);
                await _adminContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _adminContext.DisposeAsync();
            }
        }

        public async Task<bool> Editar(Tag tag)
        {
            var tagExistente = await _adminContext.MH_TAGS.FindAsync(tag.Id);

            if (tagExistente == null)
            {
                return false;
            }

            _adminContext.Entry(tagExistente).CurrentValues.SetValues(tag);

            await _adminContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var tag = new Tag { Id = id };
                _adminContext.Entry(tag).State = EntityState.Deleted;
                await _adminContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Tag> GetTagById(int id)
        {
            return await _adminContext.MH_TAGS.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _adminContext.MH_TAGS.ToListAsync();
        }
    }
}
