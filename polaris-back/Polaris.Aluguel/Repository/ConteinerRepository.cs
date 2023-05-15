using Microsoft.EntityFrameworkCore;
using Polaris.Aluguel.Context;
using Polaris.Aluguel.Models;

namespace Polaris.Aluguel.Repository
{
    public class ConteinerRepository : Repository<Models.Conteiner>, IConteinerRepository
    {
        private readonly AppDbContext _context;

        public ConteinerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetConteinerID(Guid uuid) => _context.Set<Conteiner>().AsNoTracking().Where(x => x.ConteinerUuid == uuid).FirstOrDefault().ConteinerId;
    }
}
