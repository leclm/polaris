using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Context;
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
        public IEnumerable<Models.Terceirizado> GetTerceirizadosPorServico(string servico)
        {
            return GetAllByParameter(t => t.Servicos.Any(s => s.Nome == servico)).Include(x => x.Servicos);
        }
    }
}
