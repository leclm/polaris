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
    }
}
