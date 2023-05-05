using Polaris.Usuario.Context;

namespace Polaris.Usuario.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        //private ServicoRepository _servicoRepo;
        //private TerceirizadoRepository _terceirizadoRepo;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }
        //public IServicoRepository ServicoRepository
        //{
        //    get
        //    {
        //        return _servicoRepo = _servicoRepo ?? new ServicoRepository(_context);
        //    }
        //}

        //public ITerceirizadoRepository TerceirizadoRepository
        //{
        //    get
        //    {
        //        return _terceirizadoRepo = _terceirizadoRepo ?? new TerceirizadoRepository(_context);
        //    }
        //}

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
