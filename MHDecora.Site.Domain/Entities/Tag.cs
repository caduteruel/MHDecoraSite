using System.ComponentModel.DataAnnotations;

namespace MHDecora.Site.Domain.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
