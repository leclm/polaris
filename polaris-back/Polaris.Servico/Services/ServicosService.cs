using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Repository;
using Polaris.Servico.Utils;
using Polaris.Servico.ViewModels;
using static Polaris.Servico.Exceptions.CustomExceptions;

namespace Polaris.Servico.Services
{
    public class ServicosService : IServicosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public ServicosService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<RetornoServicoViewModel> GetServicosPorTerceirizado(string cnpj)
        {
            var servicos = _context.ServicoRepository.GetServicosPorTerceirizado(cnpj);
            if (servicos.Count() == 0)
            {
                throw new ServicoNaoEncontradoException("Nenhum resultado encontrado.");
            }
            var servicosDto = _mapper.Map<List<RetornoServicoViewModel>>(servicos);
            return servicosDto;
        }

        public async Task<IEnumerable<RetornoServicoViewModel>> GetServicos()
        {
            var servicos = await _context.ServicoRepository.Get().ToListAsync();
            if (servicos is null)
            {
                throw new ServicoNaoEncontradoException("Não há serviços cadastrados.");
            }
            var servicosDto = _mapper.Map<List<RetornoServicoViewModel>>(servicos);
            return servicosDto;
        }

        public async Task<RetornoServicoViewModel> GetServico(Guid uuid)
        {
            var servico = await _context.ServicoRepository.GetByParameter(p => p.ServicoUuid == uuid);

            if (servico is null)
            {
                throw new ServicoNaoEncontradoException("Não há serviços cadastrados.");
            }
            var servicoDto = _mapper.Map<RetornoServicoViewModel>(servico);
            return servicoDto;
        }

        public async Task<Guid> PostServico(CadastroServicoViewModel servicoDto)
        {
            if (await _context.ServicoRepository.GetByParameter(x => x.Nome == servicoDto.Nome) is not null)
            {
                throw new CadastrarServicoException("Serviço já existe. Erro ao cadastrar um serviço.");
            };

            var servico = _mapper.Map<Models.Servico>(servicoDto);
            StringUtils.ClassToUpper(servico);
            servico.ServicoUuid = Guid.NewGuid();
            servico.Status = true;

            if (servico is null)
            {
                throw new CadastrarServicoException("Serviço inválido. Erro ao cadastrar um serviço.");
            }

            _context.ServicoRepository.Add(servico);
            await _context.Commit();
            return servico.ServicoUuid;
        }

        public async Task PutServico(AtualizaServicoViewModel servicoDto)
        {

            if (servicoDto.ServicoUuid == Guid.Empty)
            {
                throw new AtualizarServicoException("Serviço inválido. Erro ao atualizar o serviço.");
            }

            var servico = await _context.ServicoRepository.GetByParameter(p => p.ServicoUuid == servicoDto.ServicoUuid);

            if (servico == null)
            {
                throw new AtualizarServicoException("Serviço não encontrado. Erro ao atualizar o serviço.");
            }

            if (servico.ServicoId != 0)
            {
                var servicoMap = _mapper.Map<Models.Servico>(servicoDto);
                var servicoBase = await _context.ServicoRepository.GetByParameter(p => p.ServicoUuid == servicoMap.ServicoUuid);
                servicoMap.Status = servicoBase.Status;
                StringUtils.ClassToUpper(servico);
                servicoMap.ServicoId = servico.ServicoId;

                _context.ServicoRepository.Update(servicoMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarServicoException("Serviço inválido. Erro ao atualizar o serviço.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var servico = await _context.ServicoRepository.GetByParameter(p => p.ServicoUuid == uuid);

            if (servico == null)
            {
                throw new ServicoNaoEncontradoException("Serviço não encontrado.");
            }

            servico.Status = status;

            _context.ServicoRepository.Update(servico);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaServicoViewModel>(servico);
        }
    }
}
