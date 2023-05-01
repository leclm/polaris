using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Context;
using Polaris.Conteiner.Models;

namespace Polaris.Conteiner.Repository
{
    public class TerceirizadoRepository : Repository<Terceirizado>, ITerceirizadoRepository
    {
        private readonly AppDbContext _context;
        public TerceirizadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Guid> GetTerceirizadoUuid(int id)
        {
            var terceirizado = await _context.Set<Terceirizado>().AsNoTracking().Where(x => x.TerceirizadoId == id).FirstOrDefaultAsync();
            return terceirizado.TerceirizadoUuid;
        }

      
    }
}
