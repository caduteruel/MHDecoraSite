using System.ComponentModel.DataAnnotations;

namespace MHDecora.Site.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; } 
    }
}
