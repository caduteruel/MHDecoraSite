using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

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
            List<Montagem> listaMontagens = new List<Montagem>();

            //Montagem montagem = new Montagem();
            //montagem.Id = 1;
            //montagem.LinkBotao = "/montagem";
            //montagem.CaminhoImagem = "/image/img1.jpg";
            //montagem.TextoBotao = "Saiba mais";
            //montagem.TextoImagem = "Decorações";
            //montagem.Texto = "A MH Decora é uma loja especializada em montagens para festas.";

            //listaMontagens.Add(montagem);

            //montagem = new Montagem();
            //montagem.Id = 2;
            //montagem.LinkBotao = "/montagem";
            //montagem.CaminhoImagem = "/image/img2.jpg";
            //montagem.TextoBotao = "Saiba mais";
            //montagem.TextoImagem = "Decorações";
            //montagem.Texto = "Mesas tradicionais com decorações modernas dos temas mais pedidos no mercado, disponíveisno tamaho P e G.";
            
            //listaMontagens.Add(montagem);

            //montagem = new Montagem();
            //montagem.Id = 3;
            //montagem.LinkBotao = "/montagem";
            //montagem.CaminhoImagem = "/image/img3.jpg";
            //montagem.TextoBotao = "Saiba mais";
            //montagem.TextoImagem = "Projetos Personalizados";
            //montagem.Texto = "A MH Decora é uma loja especializada em montagens para festas.";
            
            //listaMontagens.Add(montagem);

            //montagem = new Montagem();
            //montagem.Id = 4;
            //montagem.LinkBotao = "/montagem";
            //montagem.CaminhoImagem = "/image/img1.jpg";
            //montagem.TextoBotao = "Saiba mais";
            //montagem.TextoImagem = "Decorações";
            //montagem.Texto = "Mesas tradicionais com decorações modernas dos temas mais pedidos no mercado, disponíveisno tamaho P e G.";

            //listaMontagens.Add(montagem);

            //listaMontagens = await _context.MH_MONTAGEM.ToListAsync();

            foreach (var item in listaMontagens)
            {
                item.CaminhoImagem = GetMontagemPath() + item.CaminhoImagem;
            }
            return listaMontagens;
        }

        private string GetMontagemPath()
        {
            return _configuration["ImagePath:QuemSomos"];
        }
    }
}
