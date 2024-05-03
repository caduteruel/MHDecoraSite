using MHDecora.Site.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MHDecora.Site.Infra
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
        }

        public DbSet<Banner> Banners { get; set; }
    }
}
