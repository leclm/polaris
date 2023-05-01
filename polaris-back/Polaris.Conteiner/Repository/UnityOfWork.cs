using Polaris.Conteiner.Context;

namespace Polaris.Conteiner.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private TipoConteinerRepository _tipoConteinerRepository;
        private CategoriaConteinerRepository _categoriaConteinerRepository;
        private ConteinerRepository _conteinerRepository;
        private PrestacaoServicoRepository _prestacaoDeServicoRepository;
        private TerceirizadoRepository _terceirizadoRepo;
        private ServicoRepository _servicoRepository;
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

        public ITerceirizadoRepository TerceirizadoRepository
        {
            get
            {
                return _terceirizadoRepo = _terceirizadoRepo ?? new TerceirizadoRepository(_context);
            }
        }

        public IServicoRepository ServicoRepository
        {
            get
            {
                return _servicoRepository = _servicoRepository ?? new ServicoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
