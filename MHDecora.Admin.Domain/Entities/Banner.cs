using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Domain.Entities
{
    [Table("MHBanners", Schema = "DECORAPHP")]
    public class Banner
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string CaminhoImagem { get; set; }
        public int Ordem { get; set; }
    }
}
