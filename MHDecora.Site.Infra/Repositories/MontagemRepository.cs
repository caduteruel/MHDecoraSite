using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace MHDecora.Site.Infra.Repositories
{
    public class MontagemRepository : IMontagemRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public MontagemRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Montagem>> Buscar()
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.MontagemDestaque).ToListAsync();

            return listaMontagens;
        }

        public async Task<List<Montagem>> BuscarDestaque()
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.MontagemDestaque)
                                                                                        .Include(x => x.Categoria)
                                                                                        .ToListAsync();


            foreach (var item in listaMontagens)
            {
                item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;
                item.CaminhoImagem2 = GetPathImagens() + item.CaminhoImagem2;
                item.CaminhoImagem3 = GetPathImagens() + item.CaminhoImagem3;
                item.CaminhoImagem4 = GetPathImagens() + item.CaminhoImagem4;
            }

            return listaMontagens;
        }

        public async Task<List<Montagem>> BuscarPorCategoria(int categoriaId)
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.CategoriaId == categoriaId)
                                                           .Include(x => x.Categoria)
                                                           .ToListAsync();

            foreach (var item in listaMontagens)
            {
                item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;
                item.CaminhoImagem2 = GetPathImagens() + item.CaminhoImagem2;
                item.CaminhoImagem3 = GetPathImagens() + item.CaminhoImagem3;
                item.CaminhoImagem4 = GetPathImagens() + item.CaminhoImagem4;

            }

            if (listaMontagens.Count() == 0)
            {
                var categoria = await _context.MH_CATEGORIAS.Where(x => x.Id == categoriaId).FirstOrDefaultAsync();            

                Montagem montagem = new Montagem();

                montagem.Categoria = new Categoria();

                montagem.Categoria.Nome = categoria.Nome;

                listaMontagens.Add(montagem);
            }

            return listaMontagens;
        }

        public async Task<Detalhe> BuscarPorId(int montagemId)
        {
            Detalhe detalhe = new Detalhe();

            Montagem montagem = new Montagem();

            montagem = await _context.MH_MONTAGEM.Where(x => x.Id == montagemId).FirstOrDefaultAsync();

            montagem.CaminhoImagem = montagem.CaminhoImagem == null ? montagem.CaminhoImagem : GetPathImagens() + montagem.CaminhoImagem;
            montagem.CaminhoImagem2 = montagem.CaminhoImagem2 == null ? montagem.CaminhoImagem2 : GetPathImagens() + montagem.CaminhoImagem2;
            montagem.CaminhoImagem3 = montagem.CaminhoImagem3 == null ? montagem.CaminhoImagem3 : GetPathImagens() + montagem.CaminhoImagem3;
            montagem.CaminhoImagem4 = montagem.CaminhoImagem4 == null ? montagem.CaminhoImagem4 : GetPathImagens() + montagem.CaminhoImagem4;

            detalhe.ListaMontagem.Add(montagem);

            var atuais = await _context.MH_MONTAGEM.Take(4).ToListAsync();
            atuais.RemoveAt(0); // Remove o 0 que é o de cima :-)

            foreach (var item in atuais)
            {
                if (item.CaminhoImagem.Contains("/images/"))
                {
                    detalhe.ListaMontagem.Add(item);
                }
                else
                {
                    item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;
                    item.CaminhoImagem2 = GetPathImagens() + item.CaminhoImagem2;
                    item.CaminhoImagem3 = GetPathImagens() + item.CaminhoImagem3;
                    item.CaminhoImagem4 = GetPathImagens() + item.CaminhoImagem4;

                    detalhe.ListaMontagem.Add(item);
                }
            }

            return detalhe;
        }

        public async Task<List<Montagem>> BuscarPorTagsTema(int temaId)
        {
            try
            {
                // Buscar o tema para recuprar suas TAGs
                var tema = await _context.MH_TEMA.Where(x => x.Id == temaId).FirstOrDefaultAsync();
                
                if (tema != null)
                if (tema.Tags != null)
                {                       
                    var listaTemaTags = tema.Tags.Split(",").Select(tag => tag.Trim()).ToList();

                    var palavrasChaveTags = new HashSet<string>(listaTemaTags);

                    // Obter todas as montagens do banco de dados
                    var todasMontagens = await _context.MH_MONTAGEM.Include(x => x.Categoria).AsNoTracking().ToListAsync();

                    // Filtrar em memória utilizando Any e Contains
                    var listaMontagens = todasMontagens
                        .Where(x => x.Tags != null && x.Tags.Split(",").Select(tag => tag.Trim()).Any(tag => palavrasChaveTags.Contains(tag)))
                        .ToList();

                    foreach (var item1 in listaMontagens)
                    {
                        item1.CaminhoImagem = GetPathImagens() + item1.CaminhoImagem;
                        item1.CaminhoImagem2 = GetPathImagens() + item1.CaminhoImagem2;
                        item1.CaminhoImagem3 = GetPathImagens() + item1.CaminhoImagem3;
                        item1.CaminhoImagem4 = GetPathImagens() + item1.CaminhoImagem4;
                    }

                    if (listaMontagens.Count() == 0)
                    {
                        Montagem montagem = new Montagem();

                        montagem.NomeTema = tema.Titulo;

                        listaMontagens.Add(montagem);
                    }

                    return listaMontagens;
                }

                return new List<Montagem>();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao processar: " + ex.Message);
            }
        }

        public async Task<List<Montagem>> Pesquisa(string texto)
        {

            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.Tags.Contains(texto)).ToListAsync();

            if (listaMontagens.Any())
            {
                foreach (var item in listaMontagens)
                {
                    item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;
                    item.CaminhoImagem2 = GetPathImagens() + item.CaminhoImagem2;
                    item.CaminhoImagem3 = GetPathImagens() + item.CaminhoImagem3;
                    item.CaminhoImagem4 = GetPathImagens() + item.CaminhoImagem4;
                }

                return listaMontagens;
            }

            return new List<Montagem>();
        }

        private string GetPathImagens()
        {
            return _configuration["ImagePath:Imagens"] + "/montagem/";
        }
    }
}
