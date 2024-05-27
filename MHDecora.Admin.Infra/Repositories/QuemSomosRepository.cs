using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
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

        public async Task<bool> Editar(QuemSomos dados, IFormFile imagem)
        {
            var imagemExistente = await _adminContext.MH_QUEMSOMOS.FindAsync(dados.Id);


            if (imagemExistente == null)
            {
                return false;
            }

            dados.CaminhoImagem = imagemExistente.CaminhoImagem;

            if (imagem != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "quemsomos");
                var nomeArquivoAntigo = imagemExistente.CaminhoImagem;
                var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
                File.Delete(caminhoCompletoAntigo);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + imagem.FileName;
                var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

                using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
                {
                    imagem.CopyTo(fileStream);
                }

                dados.CaminhoImagem = nomeArquivoNovo;

            }

            _adminContext.Entry(imagemExistente).CurrentValues.SetValues(dados);

            await _adminContext.SaveChangesAsync();

            return true;
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
    }
}
