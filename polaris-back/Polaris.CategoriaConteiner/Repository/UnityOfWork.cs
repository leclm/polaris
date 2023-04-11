using Polaris.CategoriaConteiner.Context;

namespace Polaris.CategoriaConteiner.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private CategoriaConteinerRepository _categoriaConteinerRepository;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }
        public ICategoriaConteinerRepository CategoriaConteinerRepository
        {
            get
            {
                return _categoriaConteinerRepository = _categoriaConteinerRepository ?? new CategoriaConteinerRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
