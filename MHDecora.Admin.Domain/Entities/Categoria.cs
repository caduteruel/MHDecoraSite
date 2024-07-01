using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHDecora.Admin.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string? CaminhoImagem { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }

        [NotMapped]
        public bool Status1 { get; set; }
    }
}
