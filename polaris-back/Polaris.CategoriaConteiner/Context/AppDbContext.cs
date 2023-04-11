using Microsoft.EntityFrameworkCore;

namespace Polaris.CategoriaConteiner.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.CategoriaConteiner>? CategoriaConteineres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.CategoriaConteiner>()
                .HasIndex(p => new { p.Nome })
                .IsUnique();
        }
    }
}
