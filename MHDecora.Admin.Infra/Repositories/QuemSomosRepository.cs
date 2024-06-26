using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Infra.Repositories
{
    public class QuemSomosRepository : IQuemSomosRepository
    {
        public readonly AdminContext _adminContext;
        private readonly IConfiguration _configuration;

        public QuemSomosRepository(AdminContext adminContext, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _configuration = configuration;
        }

        public async Task<QuemSomos> GetDados()
        {
            var quemSomos = await _adminContext.MH_QUEMSOMOS
                                    .OrderByDescending(x => x.Id)
                                    .FirstOrDefaultAsync();
            if(quemSomos != null)
            {
                quemSomos.CaminhoImagem = GetPathImagens() + quemSomos.CaminhoImagem;
            }
            
            return quemSomos;
        }

        public async Task Salvar(QuemSomos dados, IFormFile imagem)
        {
            try
            {
                if (imagem != null && imagem.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;
                    string filePath = Path.Combine("/var/aspnetcore/mhdecora_imagens/quemsomos/", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imagem.CopyTo(fileStream);
                    }
                    dados.CaminhoImagem = uniqueFileName;
                }

                _adminContext.MH_QUEMSOMOS.Add(dados);
                await _adminContext.SaveChangesAsync();


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

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/quemsomos/";
        }
    }
}
