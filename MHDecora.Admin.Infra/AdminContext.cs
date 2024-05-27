using MHDecora.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        public DbSet<QuemSomos> MH_QUEMSOMOS { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.1.100.95)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ofuracao)));User Id=furacaophp;Password=furacaoadm321");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Banner>()
                .ToTable("MH_BANNERS", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<QuemSomos>()
                .ToTable("MH_QUEMSOMOS", "DECORAPHP")
                .HasKey(x => x.Id);
        }
    }
}
