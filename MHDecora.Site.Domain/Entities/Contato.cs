using System.ComponentModel.DataAnnotations;

namespace MHDecora.Site.Domain.Entities
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string HorarioAtendimento { get; set; }
        public string Endereco { get; set; }
        //public string Mapa { get; set; }
        //public string LinkEndereço { get; set; }
    }
}
