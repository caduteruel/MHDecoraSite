using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Domain.Entities
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; }
        public bool AindaNaoDefiniODia { get; set; }
        public string MaisInformacoes { get; set; }
    }
}
