using Polaris.TipoConteiner.Context;

namespace Polaris.TipoConteiner.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private TipoConteinerRepository _tipoConteinerRepository;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ITipoConteinerRepository TipoConteinerRepository
        {
            get
            {
                return _tipoConteinerRepository = _tipoConteinerRepository ?? new TipoConteinerRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
