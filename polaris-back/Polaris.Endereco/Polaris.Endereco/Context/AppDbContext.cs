using Microsoft.EntityFrameworkCore;

namespace Polaris.Endereco.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Endereco>? Enderecos { get; set; }
        public DbSet<Models.Terceirizado>? Terceirizados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Endereco>()
               .HasIndex(p => new { p.EnderecoUuid })
               .IsUnique();

            modelBuilder.Entity<Models.Terceirizado>().Metadata.SetIsTableExcludedFromMigrations(true);
        }

    }
}
