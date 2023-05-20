using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Context;
using Polaris.Conteiner.Enums;
using Polaris.Conteiner.Pagination;
using System.Collections.Generic;

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
            return GetAllByParameter(x => x.Status == true && x.Estado == EstadoConteiner.Disponível)
                .Include(x => x.CategoriaConteiner)
                .Include(x => x.TipoConteiner);
        }

        public IEnumerable<Models.Conteiner> GetConteineresAtivosDisponiveisPorCategoriaETipo(Guid categoria, Guid tipo)
        {
            return GetAllByParameter(
                x => x.Status == true && x.Estado == EstadoConteiner.Disponível
                && x.CategoriaConteiner.CategoriaConteinerUuid == categoria
                && x.TipoConteiner.TipoConteinerUuid == tipo)
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
                 .Where(x => x.Status == true)
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

        //public async Task<IEnumerable<Models.Conteiner?>> GetConteineresByAluguel(Guid uuidAluguel)
        //{

        //    using (_context)
        //    {
        //        var query = (from e in _context.Conteineres
        //                     join t in _context.Alugueis
        //                     on e.ConteinerId equals t.ConteinerId
        //                     where t.AluguelUuid == uuidAluguel
        //                     select e);

        //        if (query is not null && query.Any())
        //        {
        //            return query.FirstOrDefault();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

    }
}
