using System.ComponentModel.DataAnnotations;

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
    }
}
