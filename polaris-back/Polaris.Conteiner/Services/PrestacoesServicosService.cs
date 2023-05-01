using AutoMapper;
using Polaris.Conteiner.Enums;
using Polaris.Conteiner.ExternalServices;
using Polaris.Conteiner.Models;
using Polaris.Conteiner.Repository;
using Polaris.Conteiner.Utils;
using Polaris.Conteiner.ViewModels;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Services
{
    public class PrestacoesServicosService : IPrestacoesServicosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly IServicoExternalService _servicoExternalService;
        private readonly ITerceirizadoRepository _terceirizadoRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly PrestacaoServicoRepository _prestacaoServicoRepository;


        public PrestacoesServicosService(IUnityOfWork context, IMapper mapper, IServicoExternalService servicoExternalService, ITerceirizadoRepository terceirizadoRepository, IServicoRepository servicoRepository)
        {
            _context = context;
            _mapper = mapper;
            _servicoExternalService = servicoExternalService;
            _terceirizadoRepository = terceirizadoRepository;
            _servicoRepository = servicoRepository;
        }

        public async Task<IEnumerable<RetornoPrestacaoDeServicoViewModel>> GetPrestacaoDeServicos()
        {
            var prestacoes = _context.PrestacaDeServicoRepository.GetPrestacaoCompleta();
            if (!prestacoes.Any())
            {
                throw new PrestacaoServicoNaoEncontradaException("Não há prestações de serviço cadastradas.");
            }

            var listaPrestacoes = new List<RetornoPrestacaoDeServicoViewModel>();
            foreach (var prestacao in prestacoes)
            {
                var prestacaoMap = _mapper.Map<RetornoPrestacaoDeServicoViewModel>(prestacao);
                prestacaoMap.Terceirizado = await _servicoExternalService.GetTerceirizado(prestacaoMap.PrestacaoDeServicoUuid);
                prestacaoMap.Servico = await _servicoExternalService.GetServico(prestacaoMap.PrestacaoDeServicoUuid);
                listaPrestacoes.Add(prestacaoMap);
            }

            return listaPrestacoes;
        }

        public async Task<RetornoPrestacaoDeServicoViewModel> GetPrestacaoDeServico(Guid uuid)
        {
            var prestacao = await _context.PrestacaDeServicoRepository.GetPrestacaoDeServico(uuid);
            var prestacaoMap = _mapper.Map<RetornoPrestacaoDeServicoViewModel>(prestacao);
            prestacaoMap.Terceirizado = await _servicoExternalService.GetTerceirizado(prestacaoMap.PrestacaoDeServicoUuid);
            prestacaoMap.Servico = await _servicoExternalService.GetServico(prestacaoMap.PrestacaoDeServicoUuid);
            return prestacaoMap;
        }

        public async Task<Guid> PostPrestacaoDeServico(CadastroPrestacaoDeServicoViewModel prestacaoDto)
        {
            return Guid.NewGuid();
            //if (await _context.PrestacaDeServicoRepository.GetByParameter(x => x.DataProcedimento == prestacaoDto.DataProcedimento
            //&& x.Conteiner.Equals(prestacaoDto.Conteiner)
            //&& x.Terceirizado.Equals(prestacaoDto.Tercerizado)) is not null)
            //{
            //    throw new CadastrarPrestacaoServicoException("Prestação de serviço já existe. Erro ao cadastrar a prestação.");
            //};

            //var prestacao = _mapper.Map<Models.PrestacaoDeServico>(prestacaoDto);
            //StringUtils.ClassToUpper(prestacao);
            //prestacao.PrestacaoDeServicoUuid = Guid.NewGuid();

            //if (prestacaoDto.Conteiner != Guid.Empty)
            //{
            //    var conteiner = await _context.ConteinerRepository.GetByParameter(x => x.ConteinerUuid == prestacaoDto.Conteiner);
            //    if (conteiner != null && conteiner.Status != false)
            //    {
            //        prestacao.ConteinerId = conteiner.ConteinerId;
            //    }
            //    else
            //    {
            //        throw new CadastrarPrestacaoServicoException("Conteiner inválido. Erro ao cadastrar o conteiner.");
            //    }
            //}
            //else
            //{
            //    throw new CadastrarPrestacaoServicoException("Conteiner inválido. Erro ao cadastrar o conteiner.");
            //}


            //if (prestacaoDto.Tercerizado != Guid.Empty)
            //{
            //    var terceirizado = await _context.TerceirizadoRepository. (x => x.TerceirizadoUuid == prestacaoDto.Tercerizado);
            //    if (terceirizado != null && terceirizado.Status != false)
            //    {
            //        prestacao.TipoConteinerId = terceirizado.TipoConteineroId;
            //    }
            //    else
            //    {
            //        throw new CadastrarConteinerException("Tipo inválido. Erro ao cadastrar o conteiner.");
            //    }
            //}
            //else
            //{
            //    throw new CadastrarConteinerException("Tipo inválido. Erro ao cadastrar o conteiner.");
            //}

            //if (prestacaoDto.Servico != Guid.Empty)
            //{
            //    var terceirizado = await _context.TerceirizadoRepository. (x => x.TerceirizadoUuid == prestacaoDto.Tercerizado);
            //    if (terceirizado != null && terceirizado.Status != false)
            //    {
            //        prestacao.TipoConteinerId = terceirizado.TipoConteineroId;
            //    }
            //    else
            //    {
            //        throw new CadastrarConteinerException("Tipo inválido. Erro ao cadastrar o conteiner.");
            //    }
            //}
            //else
            //{
            //    throw new CadastrarConteinerException("Tipo inválido. Erro ao cadastrar o conteiner.");
            //}

            //prestacao.Estado = EstadoConteiner.Disponível;
            //prestacao.Status = true;

            //_context.ConteinerRepository.Add(prestacao);
            //await _context.Commit();

            //return prestacao.ConteinerUuid;
        }
    }
}
