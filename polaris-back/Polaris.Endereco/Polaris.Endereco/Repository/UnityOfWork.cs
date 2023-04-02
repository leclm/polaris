using Polaris.Endereco.Context;

namespace Polaris.Endereco.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private EnderecoRepository _enderecoRepo;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                return _enderecoRepo = _enderecoRepo ?? new EnderecoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
