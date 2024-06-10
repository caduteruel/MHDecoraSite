using MHDecora.Admin.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MHDecora.Site.Domain.Entities
{
    public class Montagem
    {
        [Key]
        public int Id { get; set; }
        public string? CaminhoImagem { get; set; }
        public string? CaminhoImagem2 { get; set; }
        public string? CaminhoImagem3 { get; set; }
        public string? CaminhoImagem4 { get; set; }
        public string TextoImagem { get; set; }
        public string Texto { get; set; }
        public string Titulo { get; set; }
        public string LinkBotao { get; set; }
        public bool MontagemDestaque { get; set; }
        public string? Tags { get; set; }

        [NotMapped]
        public List<Tag> TagsList { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
