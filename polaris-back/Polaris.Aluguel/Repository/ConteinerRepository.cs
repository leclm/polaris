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

        public (int, int, int) GetConteinerIds(Guid conteinerUuid, Guid categoriaUuid, Guid tipoUuid)
        {
            var conteinerId = _context.Set<Conteiner>().AsNoTracking().Where(x => x.ConteinerUuid == conteinerUuid).FirstOrDefault().ConteinerId;
            var categoriaId = _context.Set<CategoriaConteiner>().AsNoTracking().Where(x => x.CategoriaConteinerUuid == categoriaUuid).FirstOrDefault().CategoriaConteinerId;
            var tipoId = _context.Set<TipoConteiner>().AsNoTracking().Where(x => x.TipoConteinerUuid == tipoUuid).FirstOrDefault().TipoConteineroId;
            return (conteinerId, categoriaId, tipoId);
        }
    }
}
