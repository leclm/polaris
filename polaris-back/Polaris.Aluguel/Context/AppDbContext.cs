using Microsoft.EntityFrameworkCore;
using Polaris.Aluguel.Models;

namespace Polaris.Aluguel.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Aluguel>? Alugueis { get; set; }
        public DbSet<Models.Cliente>? Clientes { get; set; }
        public DbSet<Models.Endereco>? Enderecos { get; set; }
        public DbSet<Models.Conteiner>? Conteineres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Aluguel>()
                .HasIndex(p => new { p.AluguelId })
                .IsUnique();

            modelBuilder.Entity<Endereco>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Cliente>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Conteiner>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<CategoriaConteiner>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<TipoConteiner>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}
