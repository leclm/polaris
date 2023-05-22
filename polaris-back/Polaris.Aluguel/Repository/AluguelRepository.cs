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
            return Get().First();
        }
        public IEnumerable<Models.Aluguel> GetAlugueisPorCpf(string cpf)
        {
            return Get();
        }
    }
}
