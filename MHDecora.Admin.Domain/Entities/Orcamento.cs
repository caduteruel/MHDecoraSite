using System.ComponentModel.DataAnnotations;

namespace MHDecora.Admin.Domain.Entities
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; }
        public bool DefinioDia { get; set; }
        public string MaisInformacao { get; set; }
    }
}
