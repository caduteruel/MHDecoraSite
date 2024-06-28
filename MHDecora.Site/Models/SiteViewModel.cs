using MHDecora.Site.Domain.Entities;

namespace MHDeroca.Site.Models
{
    public class SiteViewModel
    {
        public MidiaSocial MidiaSocial { get; set; }
        public List<Banner> Banners { get; set; }
        public QuemSomos QuemSomos { get; set; }
        public List<Montagem> Montagens { get; set; }
        public List<Tema> Temas { get; set; }
        public Contato Contato { get; set; }
        public List<Montagem> Galerias { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
