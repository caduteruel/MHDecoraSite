using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MHDecora.Admin.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string? CaminhoImagem { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; } 
    }
}
