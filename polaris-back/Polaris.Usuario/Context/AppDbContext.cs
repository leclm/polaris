using Microsoft.EntityFrameworkCore;
using Polaris.Usuario.Models;

namespace Polaris.Usuario.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Cliente>? Clientes { get; set; }
        public DbSet<Models.Gerente>? Gerentes { get; set; }
        public DbSet<Models.Login>? Logins { get; set; }
        public DbSet<Models.Endereco>? Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cliente>()
                .HasIndex(p => new { p.Cpf })
                .IsUnique();

            modelBuilder.Entity<Models.Gerente>()
              .HasIndex(p => new { p.Cnpj, p.Empresa, p.Email, p.Telefone })
              .IsUnique();

            modelBuilder.Entity<Models.Login>()
               .HasIndex(p => new { p.Usuario })
            .IsUnique();

            modelBuilder.Entity<Endereco>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}
