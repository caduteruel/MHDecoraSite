using MHDecora.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MHDecora.Admin.Infra
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }

        public DbSet<Banner> MH_BANNERS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Banner>()
                .ToTable("MH_BANNERS", "DECORAPHP"); // Define o nome da tabela e o schema
        }
    }
}
