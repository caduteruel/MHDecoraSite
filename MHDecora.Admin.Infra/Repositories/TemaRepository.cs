using MHDecora.Admin.Domain.Entities;
using MHDecora.Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace MHDecora.Admin.Infra.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly AdminContext _context;
        private readonly IConfiguration _configuration;

        public TemaRepository(AdminContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Tema>> Buscar()
        {
            List<Tema> listaTemas = await _context.MH_TEMA.ToListAsync();

            foreach (var item in listaTemas)
            {
                item.CaminhoImagem = GetTemaPath() + item.CaminhoImagem;
            }

            return listaTemas;
        }

        public async Task<Tema> BuscarPorId(int id)
        {
           Tema tema = await _context.MH_TEMA.FindAsync(id);

            tema.CaminhoImagem = GetTemaPath() + tema.CaminhoImagem;

            return tema;
        }

        public async Task<bool> Salvar(Tema tema, IFormFile arquivo)
        {
            try
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    string roothPath = Directory.GetCurrentDirectory();
                    string uploadsFolder = Path.Combine(roothPath, "wwwroot", "images/tema");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        arquivo.CopyTo(fileStream);
                    }
                    tema.CaminhoImagem = uniqueFileName;
                }

                _context.MH_TEMA.Add(tema);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _context.DisposeAsync();
            }
        }

        public async Task<bool> Excluir(int temaId)
        {
            try
            {
                // Obtém o caminho completo da imagem do banner pelo ID
                string imagePath = await _context.MH_TEMA
                                                                .Where(b => b.Id == temaId)
                                                                .Select(b => b.CaminhoImagem)
                                                                .FirstOrDefaultAsync();

                if (imagePath != null)
                {
                    // Extrai apenas o nome do arquivo da parte final do caminho
                    string fileName = Path.GetFileName(imagePath);

                    // Exclui o registro do tema
                    var tema = new Banner { Id = temaId };
                    _context.Entry(tema).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();

                    // Exclui o arquivo de imagem da pasta wwwroot/banners
                    string imagePathToDelete = Path.Combine("wwwroot", "images\\tema", fileName);
                    if (File.Exists(imagePathToDelete))
                    {
                        File.Delete(imagePathToDelete);
                    }

                    return true;
                }
                else
                {
                    // Se o caminho da imagem não for encontrado, retorna false indicando que o banner não foi encontrado
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, você pode lidar com ele aqui
                // Por exemplo, logar o erro ou retornar false
                Console.WriteLine($"Erro ao excluir tema: {ex.Message}");
                return false;
            }


        }

        public async Task<bool> Editar(IFormFile arquivo, Tema tema)
        {
            var temaExistente = await _context.MH_TEMA.FindAsync(tema.Id);


            if (temaExistente == null)
            {
                return false;
            }

            tema.CaminhoImagem = temaExistente.CaminhoImagem;

            if (arquivo != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "tema");
                var nomeArquivoAntigo = temaExistente.CaminhoImagem;
                var caminhoCompletoAntigo = Path.Combine(uploadPath, nomeArquivoAntigo);
                File.Delete(caminhoCompletoAntigo);


                var nomeArquivoNovo = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                var caminhoCompletoNovo = Path.Combine(uploadPath, nomeArquivoNovo);

                using (var fileStream = new FileStream(caminhoCompletoNovo, FileMode.Create))
                {
                    arquivo.CopyTo(fileStream);
                }

                tema.CaminhoImagem = nomeArquivoNovo;

            }

            _context.Entry(temaExistente).CurrentValues.SetValues(tema);

            await _context.SaveChangesAsync();

            return true;
        }

        private string GetTemaPath()
        {
            return _configuration["ImagePath:Tema"];
        }
    }
}
