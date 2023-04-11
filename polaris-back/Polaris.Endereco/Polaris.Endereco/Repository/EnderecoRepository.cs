using Microsoft.EntityFrameworkCore;
using Polaris.Endereco.Context;
using System;
using System.Linq;

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
    }
}
