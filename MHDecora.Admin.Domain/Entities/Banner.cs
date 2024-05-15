using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Entities
{
    public class Banner
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
