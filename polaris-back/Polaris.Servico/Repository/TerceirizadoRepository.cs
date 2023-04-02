using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Context;
using Polaris.Servico.Models;
using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
{
    public class TerceirizadoRepository : Repository<Models.Terceirizado>, ITerceirizadoRepository
    {
        public TerceirizadoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Models.Terceirizado> GetTerceirizados(TerceirizadosParameters terceirizadosParameters)
        {
            return Get()
                .OrderBy(on => on.Empresa)
                .Skip((terceirizadosParameters.PageNumber - 1) * terceirizadosParameters.PageSize)
                .Take(terceirizadosParameters.PageSize)
                .ToList();
        }
        public async Task<IEnumerable<Models.Terceirizado>> GetServicosTerceirizados()
        {
            return await Get().Include(x => x.Servicos).ToListAsync();
        }
    }
}
