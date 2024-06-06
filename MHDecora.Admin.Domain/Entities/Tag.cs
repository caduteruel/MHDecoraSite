using System.ComponentModel.DataAnnotations;

namespace MHDecora.Admin.Domain.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
