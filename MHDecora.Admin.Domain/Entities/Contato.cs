using System.ComponentModel.DataAnnotations;

namespace MHDecora.Admin.Domain.Entities
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string HorarioAtendimento { get; set; }
        public string Endereco { get; set; }

        public string? LinkEndereco { get; set; }
        public string? LinkMapa { get; set; }

    }
}
