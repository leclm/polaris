using Polaris.Endereco.Context;

namespace Polaris.Endereco.Repository
{
    public class EnderecoRepository : Repository<Models.Endereco>, IEnderecoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Models.Endereco?> GetEnderecoByTerceirizado(Guid uuidTerceirizado)
        {
            using (_context)
            {
                var query = (from e in _context.Enderecos
                            join t in _context.Terceirizados
                            on e.EnderecoId equals t.EnderecoId
                            where t.TerceirizadoUuid == uuidTerceirizado
                            select e);

                if (query is not null && query.Any())
                {
                    return query.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Models.Endereco?> GetEnderecoByCliente(Guid uuidCliente)
        {
            using (_context)
            {
                var query = (from e in _context.Enderecos
                             join t in _context.Clientes
                             on e.EnderecoId equals t.EnderecoId
                             where t.ClienteUuid == uuidCliente
                             select e);

                if (query is not null && query.Any())
                {
                    return query.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Models.Endereco?> GetEnderecoByGerente(Guid uuidGerente)
        {
            using (_context)
            {
                var query = (from e in _context.Enderecos
                             join t in _context.Gerentes
                             on e.EnderecoId equals t.EnderecoId
                             where t.GerenteUuid == uuidGerente
                             select e);

                if (query is not null && query.Any())
                {
                    return query.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Models.Endereco?> GetEnderecoByAluguel(Guid uuidAluguel)
        {
            using (_context)
            {
                var query = (from e in _context.Enderecos
                             join t in _context.Alugueis
                             on e.EnderecoId equals t.EnderecoId
                             where t.AluguelUuid == uuidAluguel
                             select e);

                if (query is not null && query.Any())
                {
                    return query.First();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
