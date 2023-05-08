using Microsoft.EntityFrameworkCore;
using Polaris.Usuario.Context;
using Polaris.Usuario.Models;

namespace Polaris.Usuario.Repository
{
    public class GerenteRepository : Repository<Models.Gerente>, IGerenteRepository
    {
        private readonly AppDbContext _context;

        public GerenteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Models.Gerente> GenteGerentesCompleto()
        {
            return Get()
                .Include(x => x.Endereco)
                .Include(x => x.Login);
        }

        public IEnumerable<Models.Gerente> GetGerentesAtivosCompleto()
        {
            return GetAllByParameter(x => x.Status == true)
                  .Include(x => x.Endereco)
                  .Include(x => x.Login);
        }

        public async Task<Models.Gerente> GetGerente(Guid uuid)
        {
            return await _context.Set<Gerente>().AsNoTracking().Where(x => x.GerenteUuid == uuid)
                .Include(x => x.Endereco)
                 .Include(x => x.Login)
                .FirstOrDefaultAsync();
        }
    }
}
