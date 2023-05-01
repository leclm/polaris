using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Context;

namespace Polaris.Conteiner.Repository
{
    public class PrestacaoServicoRepository : Repository<Models.PrestacaoDeServico>, IPrestacaoServicoRepository
    {
        private readonly AppDbContext _context;

        public PrestacaoServicoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Models.PrestacaoDeServico> GetPrestacaoCompleta()
        {
            return Get().Include(x => x.Conteiner);
        }

        public async Task<Models.PrestacaoDeServico> GetPrestacaoDeServico(Guid uuid)
        {
            return await _context.Set<Models.PrestacaoDeServico>()
                .AsNoTracking()
                .Where(x => x.PrestacaoDeServicoUuid == uuid)
                .Include(x => x.Conteiner)
                .Include(x => x.Conteiner.TipoConteiner)
                .Include(x => x.Conteiner.CategoriaConteiner)
                .FirstOrDefaultAsync();
        }
    }
}
