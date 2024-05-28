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
            var quemSomos =  await _adminContext.MH_QUEMSOMOS.ToListAsync();

            quemSomos.FirstOrDefault().CaminhoImagem = GetQuemsomosPath() + quemSomos.FirstOrDefault().CaminhoImagem;

            return quemSomos.FirstOrDefault();
        }

        public async Task Salvar(QuemSomos dados, IFormFile imagem)
        {
            try
            {
                if (imagem != null && imagem.Length > 0)
                {
                    //banner.Descricao = banner.CaminhoImagem;
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/quemsomos");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imagem.CopyTo(fileStream);
                    }
                    dados.CaminhoImagem = uniqueFileName;
                }

                //_banners.Add(banner);

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

        private string GetQuemsomosPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
