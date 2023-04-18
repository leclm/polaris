using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Context;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public class ConteinerRepository : Repository<Models.Conteiner>, IConteinerRepository
    {
        private readonly AppDbContext _context;

        public ConteinerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Models.Conteiner> GetConteineresCompleto()
        {
            return Get()
                .Include(x => x.CategoriaConteiner)
                .Include(x => x.TipoConteiner);
        }

        public IEnumerable<Models.Conteiner> GetConteineresAtivosCompleto()
        {
            return GetAllByParameter(x => x.Status == true)
                .Include(x => x.CategoriaConteiner)
                .Include(x => x.TipoConteiner);
        }

        public IEnumerable<Models.Conteiner> GetConteineresAtivosDisponiveis()
        {
            return GetAllByParameter(x => x.Status == true && x.Disponivel == true)
                .Include(x => x.CategoriaConteiner)
                .Include(x => x.TipoConteiner);
        }

        public IEnumerable<Models.Conteiner> GetConteineres(ConteinerParameters conteinerParameters)
        {
            return Get()
                .OrderBy(on => on.Codigo)
                .Skip((conteinerParameters.PageNumber - 1) * conteinerParameters.PageSize)
                .Take(conteinerParameters.PageSize)
                .ToList();
        }

        public IEnumerable<Models.Conteiner> GetConteineresPorCategoria(string categoria)
        {
            return GetAllByParameter(s => s.CategoriaConteiner.Nome == categoria)
                 .Include(x => x.CategoriaConteiner)
                 .Include(x => x.TipoConteiner);
        }
        public IEnumerable<Models.Conteiner> GetConteineresPorTipo(string tipo)
        {
            return GetAllByParameter(s => s.TipoConteiner.Nome == tipo)
                 .Include(x => x.CategoriaConteiner)
                 .Include(x => x.TipoConteiner);
        }

        public async Task<Models.Conteiner> GetConteiner(Guid uuid)
        {
            return await _context.Set<Models.Conteiner>().AsNoTracking().Where(x => x.ConteinerUuid == uuid)
                .Include(x => x.CategoriaConteiner)
                 .Include(x => x.TipoConteiner)
                .FirstOrDefaultAsync();
        }
    }
}
