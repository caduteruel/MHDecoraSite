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

            return listaMontagens;
        }

        public async Task<Detalhe> BuscarPorId(int montagemId)
        {
            Detalhe detalhe = new Detalhe();

            Montagem montagem = new Montagem();

            montagem = await _context.MH_MONTAGEM.Where(x => x.Id == montagemId).FirstOrDefaultAsync();

            montagem.CaminhoImagem = GetPathImagens() + montagem.CaminhoImagem;
            montagem.CaminhoImagem2 = GetPathImagens() + montagem.CaminhoImagem2;
            montagem.CaminhoImagem3 = GetPathImagens() + montagem.CaminhoImagem3;
            montagem.CaminhoImagem4 = GetPathImagens() + montagem.CaminhoImagem4;

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
                                                    .Where(x => x.Texto.Contains(texto) || x.Titulo.Contains(texto))
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
