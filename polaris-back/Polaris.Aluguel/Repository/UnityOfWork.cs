using Polaris.Aluguel.Context;

namespace Polaris.Aluguel.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private AluguelRepository _aluguelRepo;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IAluguelRepository AluguelRepository
        {
            get
            {
                return _aluguelRepo = _aluguelRepo ?? new AluguelRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
