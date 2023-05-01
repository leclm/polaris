using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Context;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public class ServicoRepository : Repository<Models.Servico>, IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Models.Servico> GetServicos(ServicosParameters servicosParameters)
        {
            return Get()
                .OrderBy(on => on.Nome)
                .Skip((servicosParameters.PageNumber - 1) * servicosParameters.PageSize)
                .Take(servicosParameters.PageSize)
                .ToList();
        }
        public IEnumerable<Models.Servico> GetServicosPorTerceirizado(string cnpj)
        {
            return GetAllByParameter(t => t.Terceirizados.Any(s => s.Cnpj == cnpj)).Include(x => x.Terceirizados);
        }
    }
}
