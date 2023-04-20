using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Polaris.Conteiner.Models;

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
        public DbSet<Models.Terceirizado>? Terceirizados { get; set; }
        public DbSet<Models.Servico>? Servicos { get; set; }
        public DbSet<Models.Endereco>? Enderecos { get; set; }
        public DbSet<Models.PrestacaoDeServico>? PrestacaoDeServicos { get; set; }


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

            modelBuilder.Entity<Endereco>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Terceirizado>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Servico>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}
