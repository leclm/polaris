using Polaris.Usuario.Context;

namespace Polaris.Usuario.Repository
{
    public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<Models.Cliente> GetTerceirizadosCompleto()
        //{
        //    return Get().Include(x => x.Servicos);
        //}

        //public IEnumerable<Models.Terceirizado> GetTerceirizadosAtivosCompleto()
        //{
        //    return GetAllByParameter(x => x.Status == true).Include(x => x.Servicos);
        //}

        //public IEnumerable<Models.Terceirizado> GetTerceirizados(TerceirizadosParameters terceirizadosParameters)
        //{
        //    return Get()
        //        .OrderBy(on => on.Empresa)
        //        .Skip((terceirizadosParameters.PageNumber - 1) * terceirizadosParameters.PageSize)
        //        .Take(terceirizadosParameters.PageSize)
        //        .ToList();
        //}

        //public IEnumerable<Models.Terceirizado> GetTerceirizadosPorServico(string servico)
        //{
        //    return GetAllByParameter(t => t.Servicos.Any(s => s.Nome == servico)).Include(x => x.Servicos);
        //}

        //public async Task<Models.Terceirizado> GetTerceirizado(Guid uuid)
        //{
        //    return await _context.Set<Terceirizado>().AsNoTracking().Where(x => x.TerceirizadoUuid == uuid).Include(x => x.Servicos).FirstOrDefaultAsync();
        //}

        //public async Task<Models.Terceirizado?> GetTerceirizadoByPrestacaoDeServico(Guid uuidPrestacaoDeServico)
        //{
        //    using (_context)
        //    {
        //        var query = (from t in _context.Terceirizados
        //                     join p in _context.PrestacoesDeServicos
        //                     on t.TerceirizadoId equals p.TerceirizadoId
        //                     where p.PrestacaoDeServicoUuid == uuidPrestacaoDeServico
        //                     select t);

        //        if (query is not null && query.Any())
        //        {
        //            return query.Include(x => x.Servicos).First();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public void LimpaServicos(Terceirizado terceirizado)
        //{
        //    _context.Database.ExecuteSqlRaw($@"
        //        DELETE FROM polaris.servicoterceirizado
        //        WHERE TerceirizadosTerceirizadoId = {terceirizado.TerceirizadoId} 
        //    ");
        //}
    }
}
