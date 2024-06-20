using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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

            return listaMontagens;
        }

        public async Task<Montagem> BuscarPorId(int montagemId)
        {
            var listaMontagens = await _context.MH_MONTAGEM.Where(x => x.Id == montagemId).FirstOrDefaultAsync();


            listaMontagens.CaminhoImagem = GetPathImagens() + listaMontagens.CaminhoImagem;
            listaMontagens.CaminhoImagem2 = GetPathImagens() + listaMontagens.CaminhoImagem2;
            listaMontagens.CaminhoImagem3 = GetPathImagens() + listaMontagens.CaminhoImagem3;
            listaMontagens.CaminhoImagem4 = GetPathImagens() + listaMontagens.CaminhoImagem4;


            return listaMontagens;
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
                    string[] listaIdTags = tema.Tags.Split(",");

                    // Converter os IDs para inteiros (se necessário)
                    int[] ids = Array.ConvertAll(listaIdTags, int.Parse);

                    // Buscar os nomes das TAGs
                    var listaNomeTags = await _context.MH_TAGS
                        .Where(x => ids.Contains(x.Id)) // Filtra apenas as tags cujos IDs estão na lista de IDs convertidos
                        .Select(p => p.Nome) // Seleciona apenas o campo Nome
                        .ToListAsync(); // Converte o resultado para uma lista assíncrona

                    // Converter listaNomeTags para um HashSet para otimização de busca

                    if (listaNomeTags != null)
                    {
                        var palavrasChave = new HashSet<string>(listaNomeTags);
                        var palavrasChaveTags = new HashSet<string>(listaIdTags);

                        // Realiza a consulta inicial para obter todas as montagens
                        var todasMontagens = await _context.MH_MONTAGEM.ToListAsync();

                        // Filtra em memória utilizando expressões regulares para buscar parte do texto
                        var regexPadrao = new Regex(string.Join("|", palavrasChave.Select(p => Regex.Escape(p))));


                        var listaMontagens = todasMontagens
                                                    .Where(x => regexPadrao.IsMatch(x.Texto) ||
                                                                regexPadrao.IsMatch(x.Titulo) ||
                                                                regexPadrao.IsMatch(x.TextoImagem) ||
                                                    (x.Tags != null && palavrasChaveTags.Any(tag => x.Tags.Contains(tag))))
                                                .ToList();

                        foreach (var item in listaMontagens)
                        {
                            item.CaminhoImagem = GetPathImagens() + item.CaminhoImagem;
                            item.CaminhoImagem2 = GetPathImagens() + item.CaminhoImagem2;
                            item.CaminhoImagem3 = GetPathImagens() + item.CaminhoImagem3;
                            item.CaminhoImagem4 = GetPathImagens() + item.CaminhoImagem4;
                        }

                        return listaMontagens;
                    }

                    return null;
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
            var listaMontagens = await _context.MH_MONTAGEM
                                                    .Where(x => x.Texto.Contains(texto) || x.Titulo.Contains(texto) || (x.Tags != null && x.Tags.Contains(texto)))
                                                    .ToListAsync();
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
