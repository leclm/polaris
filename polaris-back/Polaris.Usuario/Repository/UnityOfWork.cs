using Polaris.Usuario.Context;

namespace Polaris.Usuario.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private LoginRepository _loginRepo;
        private ClienteRepository _clienteRepo;
        private GerenteRepository _gerenteRepo;
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

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context);
            }
        }

        public IGerenteRepository GerenteRepository
        {
            get
            {
                return _gerenteRepo = _gerenteRepo ?? new GerenteRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
