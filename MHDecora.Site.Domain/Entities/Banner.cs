namespace MHDecora.Site.Domain.Entities
{
    public class Banner
    {
        public Banner(string caminhoImagem)
        {
            CaminhoImagem = caminhoImagem;
        }

        public int Id { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
