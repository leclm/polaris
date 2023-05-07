using Polaris.Usuario.Context;

namespace Polaris.Usuario.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private LoginRepository _loginRepo;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public ILoginRepository LoginRepository
        {
            get
            {
                return _loginRepo = _loginRepo ?? new LoginRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
