using Microsoft.EntityFrameworkCore;

namespace Polaris.TipoConteiner.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.TipoConteiner>? TiposConteineres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TipoConteiner>()
                .HasIndex(p => new { p.Nome })
                .IsUnique();
        }
    }
}
