using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Context;
using Polaris.Conteiner.Models;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetServicoId(Guid uuid) => _context.Set<Servico>().AsNoTracking().Where(x => x.ServicoUuid == uuid).FirstOrDefault().ServicoId;
    }
}
