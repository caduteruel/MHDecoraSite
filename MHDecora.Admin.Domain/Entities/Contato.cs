using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Entities
{    
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CaminhoImagem { get; set; }
        public int Ordem { get; set; }
    }
}
