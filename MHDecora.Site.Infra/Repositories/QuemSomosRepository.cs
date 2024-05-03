using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;

namespace MHDecora.Site.Infra.Repositories
{
    public class QuemSomosRepository : IQuemSomosRepository
    {
        private readonly SiteContext _context;

        public QuemSomosRepository(SiteContext context)
        {
            _context = context;
        }

        public async Task<QuemSomos> Buscar()
        {
            QuemSomos quemSomos = new QuemSomos();
            quemSomos.Id = 1;
            quemSomos.Titulo = "MH Decora";
            quemSomos.CaminhoImagem = "/image/img3.jpg";
            quemSomos.Texto = "A MH Decora é uma loja especializada em montagens de  decorações para os mais diversos tipos de evento. Aqui temos decoradas parceiros e disponíveis para te ajudar a tirar a sua idéia do papel.<br><br>\r\n                        Ag werewr sdfgdf sdfg herewr oj oj sdfpohj sdf oijh  oiuhg sdoifh asdiofhg 9wer9 9u i oi oiusdhf io asd f oiu oisduf oiasud foiasd fghiosdufgiosadf gsoidf g oaisdfu.<br><br>\r\n                        Também asjdhkh iouh oisdio sd gbfiosad fisao fosiafds werwer ojkherwe iriwe grig iyeg wrigw eoirg we irwe oiw rgwe ori oi.";

            return await Task.FromResult(quemSomos);
        }
    }
}
