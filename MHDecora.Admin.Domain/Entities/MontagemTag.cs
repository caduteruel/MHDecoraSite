using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Entities
{
    public class MontagemTag
    {
        public int MontagemId { get; set; }
        public Montagem Montagem { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
