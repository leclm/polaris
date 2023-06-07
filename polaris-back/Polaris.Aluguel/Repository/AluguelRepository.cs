using Microsoft.EntityFrameworkCore;
using Polaris.Aluguel.Context;
using Polaris.Aluguel.Pagination;

namespace Polaris.Aluguel.Repository
{
    public class AluguelRepository : Repository<Models.Aluguel>, IAluguelRepository
    {
        private readonly AppDbContext _context;
        public AluguelRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Models.Aluguel> GetAlugueisCompletos()
        {
            return Get();
        }

        public IEnumerable<Models.Aluguel> GetAlugueis(AluguelParameters aluguelParameters)
        {
            return Get()
                .OrderBy(on => on.AluguelId)
                .Skip((aluguelParameters.PageNumber - 1) * aluguelParameters.PageSize)
                .Take(aluguelParameters.PageSize)
                .ToList();
        }

        public async Task<Models.Aluguel> GetAluguel(Guid uuid)
        {
            return await _context.Set<Models.Aluguel>().AsNoTracking().Where(x => x.AluguelUuid == uuid)
                .Include(x => x.Cliente)
                .Include(x => x.Conteineres)
                    .ThenInclude(x => x.TipoConteiner)
                .Include(x => x.Conteineres)
                    .ThenInclude(x => x.CategoriaConteiner)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync();
        }
        public IEnumerable<Models.Aluguel> GetAlugueisPorCpf(string cpf)
        {
            return Get().Where(x => x.Cliente.Cpf == cpf);
        }   
        
        public IEnumerable<Models.Aluguel> GetAlugueisPorConteiner(int codigo)
        {
            return GetAllByParameter(t => t.Conteineres.Any(s => s.Codigo == codigo));
        }
    }
}
