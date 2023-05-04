using AutoMapper;
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
        private readonly IConteinerRepository _conteinerRepository;
        private readonly PrestacaoServicoRepository _prestacaoServicoRepository;


        public PrestacoesServicosService(IUnityOfWork context, IMapper mapper, IServicoExternalService servicoExternalService, ITerceirizadoRepository terceirizadoRepository, IServicoRepository servicoRepository, IConteinerRepository conteinerRepository)
        {
            _context = context;
            _mapper = mapper;
            _servicoExternalService = servicoExternalService;
            _terceirizadoRepository = terceirizadoRepository;
            _servicoRepository = servicoRepository;
            _conteinerRepository = conteinerRepository;
        }

        public async Task<IEnumerable<RetornoPrestacaoDeServicoViewModel>> GetPrestacoesServicosPorConteiner(Guid uuidConteiner)
        {
            var prestacoes = _context.PrestacaDeServicoRepository.GetPrestacoesServicosPorConteiner(uuidConteiner);
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
            if (prestacaoDto.Conteiner == Guid.Empty || prestacaoDto.Conteiner == Guid.Empty || prestacaoDto.Servico == Guid.Empty)
            {
                throw new CadastrarPrestacaoServicoException("Dados inválidos. Erro ao cadastrar a prestação de serviço.");
            }

            if (await _context.PrestacaDeServicoRepository.GetByParameter(
                x => x.DataProcedimento == prestacaoDto.DataProcedimento && 
                x.Conteiner!.ConteinerUuid == prestacaoDto.Conteiner && 
                x.Terceirizado!.TerceirizadoUuid == prestacaoDto.Terceirizado &&
                x.Servico!.ServicoUuid == prestacaoDto.Servico) is not null)
            {
                throw new CadastrarPrestacaoServicoException("Prestação de serviço já existe. Erro ao cadastrar a prestação de serviço.");
            };

            var conteiner = await _conteinerRepository.GetByParameter(x => x.ConteinerUuid == prestacaoDto.Conteiner);
            var prestacao = new PrestacaoDeServico
            {
                PrestacaoDeServicoUuid = Guid.NewGuid(),
                Comentario = prestacaoDto.Comentario,
                DataProcedimento = prestacaoDto.DataProcedimento,
                EstadoPrestacaoServico = Enums.EstadoPrestacaoServico.Andamento,
                ConteinerId = conteiner.ConteinerId,
                TerceirizadoId = _terceirizadoRepository.GetTerceirizadoId(prestacaoDto.Terceirizado), 
                ServicoId = _servicoRepository.GetServicoId(prestacaoDto.Servico),
                Conteiner = null,
                Servico = null,
                Terceirizado = null
            };
            StringUtils.ClassToUpper(prestacao);

            if (prestacao.ConteinerId == 0)
            {
                throw new CadastrarPrestacaoServicoException("Conteiner inválido.  Erro ao cadastrar a prestação de serviço.");
            }

            if (prestacao.TerceirizadoId == 0)
            {
                throw new CadastrarPrestacaoServicoException("Terceirizado inválido.  Erro ao cadastrar a prestação de serviço.");
            }

            if (prestacao.ServicoId == 0)
            {
                throw new CadastrarPrestacaoServicoException("Serviço inválido.  Erro ao cadastrar a prestação de serviço.");
            }

            _context.PrestacaDeServicoRepository.Add(prestacao);
            await _context.Commit();

            return prestacao.PrestacaoDeServicoUuid;
        }

        public async Task PutEstadoPrestacaoDeServico(AlteraEstadoPrestacaoServico estado)
        {
            if (estado.PrestacaoDeServicoUuid == Guid.Empty)
            {
                throw new AtualizarPrestacaoServicoException("Prestação de Serviço inválida. Erro ao atualizar a prestação.");
            }

            var prestacao = await _context.PrestacaDeServicoRepository.GetPrestacaoDeServico(estado.PrestacaoDeServicoUuid);

            if (prestacao == null || prestacao.PrestacaoDeServicoId == 0)
            {
                throw new AtualizarPrestacaoServicoException("Prestação de Serviço inválida. Erro ao atualizar a prestação.");
            }

            prestacao.Comentario = estado.Comentario;
            prestacao.DataProcedimento = estado.DataProcedimento;
            prestacao.EstadoPrestacaoServico = estado.EstadoPrestacaoServico;
            StringUtils.ClassToUpper(prestacao);
            _context.PrestacaDeServicoRepository.Update(prestacao);

            await _context.Commit();
        }
    }
}
