using System.ComponentModel.DataAnnotations;

namespace MHDecora.Admin.Domain.Entities
{    
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string[] CaminhoImagem { get; set; }
        public string Descricao { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
