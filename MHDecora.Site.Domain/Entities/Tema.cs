using MHDecora.Admin.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHDecora.Site.Domain.Entities
{
    public class Tema
    {        
        public int Id { get; set; }
        public string CaminhoImagem { get; set; }
        public string Texto { get; set; }
        public string Titulo { get; set; }
        public string? Tags { get; set; }
        [NotMapped]
        public List<Tag> TagsList { get; set; }
    }
}
