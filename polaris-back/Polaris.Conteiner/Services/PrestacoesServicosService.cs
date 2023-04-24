using AutoMapper;
using Polaris.Conteiner.ExternalServices;
using Polaris.Conteiner.Models;
using Polaris.Conteiner.Repository;
using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public class PrestacoesServicosService : IPrestacoesServicosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly IServicoExternalService _servicoExternalService;


        public PrestacoesServicosService(IUnityOfWork context, IMapper mapper, IServicoExternalService servicoExternalService)
        {
            _context = context;
            _mapper = mapper;
            _servicoExternalService = servicoExternalService;
        }

        public async Task<RetornoPrestacaoDeServicoViewModel> GetPrestacaoDeServico(Guid uuid)
        {
            var prestacao = await _context.PrestacaDeServicoRepository.GetPrestacaoDeServico(uuid);
            var prestacaoMap = _mapper.Map<RetornoPrestacaoDeServicoViewModel>(prestacao);
            //_servicoExternalService.GetServicos();
            return prestacaoMap;
        }
    }
}
