﻿using MHDecora.Site.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Site.Infra
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
        }

        public DbSet<Banner> MH_BANNERS { get; set; }
        public DbSet<Tema> MH_TEMA { get; set; }
        public DbSet<Contato> MH_CONTATO { get; set; }
        public DbSet<QuemSomos> MH_QUEMSOMOS { get; set; }
        public DbSet<Montagem> MH_MONTAGEM { get; set; }

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

            modelBuilder.Entity<Tema>()
                .ToTable("MH_TEMA", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Montagem>()
                .ToTable("MH_MONTAGEM", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Contato>()
                .ToTable("MH_CONTATO", "DECORAPHP")
                .HasKey(x => x.Id);
        }
    }
}
