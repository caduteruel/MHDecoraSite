using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<MontagemTag> MontagensTags { get; set; }
    }
}
