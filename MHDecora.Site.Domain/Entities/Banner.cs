using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHDecora.Site.Domain.Entities
{    
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string CaminhoImagem { get; set; }
        public int Ordem { get; set; }
    }
}
