using Polaris.Conteiner.Context;

namespace Polaris.Conteiner.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private TipoConteinerRepository _tipoConteinerRepository;
        private CategoriaConteinerRepository _categoriaConteinerRepository;
        private ConteinerRepository _conteinerRepository;
        private PrestacaoServicoRepository _prestacaoDeServicoRepository;
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

        public ICategoriaConteinerRepository CategoriaConteinerRepository
        {
            get
            {
                return _categoriaConteinerRepository = _categoriaConteinerRepository ?? new CategoriaConteinerRepository(_context);
            }
        }

        public IConteinerRepository ConteinerRepository
        {
            get
            {
                return _conteinerRepository = _conteinerRepository ?? new ConteinerRepository(_context);
            }
        }
        
        public IPrestacaoServicoRepository PrestacaDeServicoRepository
        {
            get
            {
                return _prestacaoDeServicoRepository = _prestacaoDeServicoRepository ?? new PrestacaoServicoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
