using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Context;
using Polaris.Servico.Models;
using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
{
    public class ServicoRepository : Repository<Models.Servico>, IServicoRepository
    {
        public ServicoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Models.Servico> GetServicos(ServicosParameters servicosParameters)
        {
            return Get()
                .OrderBy(on => on.Nome)
                .Skip((servicosParameters.PageNumber - 1) * servicosParameters.PageSize)
                .Take(servicosParameters.PageSize)
                .ToList();
        }
        public async Task<IEnumerable<Models.Servico>> GetTerceirizadosServicos()
        {
            return await Get().Include(x => x.Terceirizados).ToListAsync();
        }
    }
}
