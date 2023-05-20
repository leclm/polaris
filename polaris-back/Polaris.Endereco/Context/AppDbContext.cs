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
        public DbSet<Models.Cliente>? Clientes { get; set; }
        public DbSet<Models.Gerente>? Gerentes { get; set; }
        public DbSet<Models.Aluguel>? Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Endereco>()
               .HasIndex(p => new { p.EnderecoUuid })
               .IsUnique();

            modelBuilder.Entity<Models.Terceirizado>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.Cliente>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.Gerente>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.Aluguel>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.Login>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.Conteiner>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.CategoriaConteiner>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Models.TipoConteiner>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity("AluguelConteiner").Metadata.SetIsTableExcludedFromMigrations(true);
        }

    }
}
