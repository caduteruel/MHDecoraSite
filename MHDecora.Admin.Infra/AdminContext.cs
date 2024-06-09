using MHDecora.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Admin.Infra
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }

        public AdminContext() : base(GetOptions())
        {
        }

        private static DbContextOptions<AdminContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminContext>();
            optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.1.100.95)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ofuracao)));User Id=furacaophp;Password=furacaoadm321");
            return optionsBuilder.Options;
        }

        public DbSet<Banner> MH_BANNERS { get; set; }
        public DbSet<QuemSomos> MH_QUEMSOMOS { get; set; }
        public DbSet<Montagem> MH_MONTAGEM { get; set; }
        public DbSet<Tema> MH_TEMA { get; set; }
        public DbSet<Categoria> MH_CATEGORIAS { get; set; }
        public DbSet<Tag> MH_TAGS { get; set; }
        public DbSet<Contato> MH_CONTATO { get; set; }
        public DbSet<Orcamento> MH_ORCAMENTO { get; set; }

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

            modelBuilder.Entity<Montagem>()
                .ToTable("MH_MONTAGEM", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Tema>()
                .ToTable("MH_TEMA", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Categoria>()
                .ToTable("MH_CATEGORIAS", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Tag>()
                .ToTable("MH_TAGS", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Contato>()
                .ToTable("MH_CONTATO", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Orcamento>()
                .ToTable("MH_ORCAMENTO", "DECORAPHP")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Montagem>(entity =>
            {
                entity.Property(e => e.MontagemDestaque)
                      .HasColumnType("NUMBER(1)")
                      .HasDefaultValue(false); // Define o valor padrão como falso
            });

        }
    }
}
