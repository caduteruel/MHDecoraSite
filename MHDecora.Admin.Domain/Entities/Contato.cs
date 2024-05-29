using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string HorarioAtendimento { get; set; }
        public string Endereco { get; set; }

    }
}
