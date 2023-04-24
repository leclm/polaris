using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Models;

namespace Polaris.Servico.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Servico>? Servicos { get; set; }
        public DbSet<Models.Terceirizado>? Terceirizados { get; set; }
        public DbSet<Models.Endereco>? Enderecos { get; set; }
        public DbSet<Models.PrestacaoDeServico>? PrestacoesDeServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Servico>()
                .HasIndex(p => new { p.Nome })
                .IsUnique();

            modelBuilder.Entity<Models.Terceirizado>()
               .HasIndex(p => new { p.Empresa, p.Cnpj, p.Email, p.Telefone })
            .IsUnique();

            modelBuilder.Entity<Endereco>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<PrestacaoDeServico>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}
