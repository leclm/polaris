using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Context;
using Polaris.Servico.Models;
using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
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
