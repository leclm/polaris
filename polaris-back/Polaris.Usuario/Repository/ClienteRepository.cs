using Microsoft.EntityFrameworkCore;
using Polaris.Usuario.Context;
using Polaris.Usuario.Models;

namespace Polaris.Usuario.Repository
{
    public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Models.Cliente> GetClientesCompleto()
        {
            return Get()
                .Include(x => x.Endereco)
                .Include(x => x.Login);
        }

        public IEnumerable<Models.Cliente> GetClientesAtivosCompleto()
        {
            return GetAllByParameter(x => x.Status == true)
                  .Include(x => x.Endereco)
                  .Include(x => x.Login);
        }

        public async Task<Models.Cliente> GetCliente(Guid uuid)
        {
            return await _context.Set<Cliente>().AsNoTracking().Where(x => x.ClienteUuid == uuid)
                .Include(x => x.Endereco)
                 .Include(x => x.Login)
                .FirstOrDefaultAsync();
        }

        public async Task<Models.Cliente?> GetClienteByAluguel(Guid uuidAluguel)
        {
            using (_context)
            {
                var query = (from e in _context.Clientes
                             join t in _context.Alugueis
                             on e.ClienteId equals t.ClienteId
                             where t.AluguelUuid == uuidAluguel
                             select e);

                if (query is not null && query.Any())
                {
                    var cliente = query.Include(x => x.Endereco)
                                        .Include(x => x.Login)
                                        .First();
                    return cliente;                    
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
