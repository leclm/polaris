using Microsoft.EntityFrameworkCore;

namespace Polaris.Conteiner.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.TipoConteiner>? TiposConteineres { get; set; }
        public DbSet<Models.CategoriaConteiner>? CategoriaConteineres { get; set; }
        public DbSet<Models.Conteiner>? Conteineres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TipoConteiner>()
                .HasIndex(p => new { p.Nome })
                .IsUnique();

            modelBuilder.Entity<Models.CategoriaConteiner>()
                .HasIndex(p => new { p.Nome })
                .IsUnique();

            modelBuilder.Entity<Models.Conteiner>()
               .HasIndex(p => new { p.Codigo })
               .IsUnique();
        } 
    }
}
