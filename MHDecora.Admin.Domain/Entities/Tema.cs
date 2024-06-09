using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHDecora.Admin.Domain.Entities
{
    public class Tema
    {
        [Key]
        public int Id { get; set; }
        public string CaminhoImagem { get; set; }
        public string Texto { get; set; }
        public string Titulo { get; set; }
        public string LinkTema { get; set; }
        public string? Tags { get; set; }
        [NotMapped]
        public List<Tag> TagsList { get; set; }
    }
}
