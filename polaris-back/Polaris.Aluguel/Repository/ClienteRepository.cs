using Microsoft.EntityFrameworkCore;
using Polaris.Aluguel.Context;
using Polaris.Aluguel.Models;

namespace Polaris.Aluguel.Repository
{
    public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetClienteId(Guid uuid) => _context.Set<Cliente>().AsNoTracking().Where(x => x.ClienteUuid == uuid).FirstOrDefault().ClienteId;
    }
}
