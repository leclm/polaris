using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Repository;
using Polaris.Servico.Utils;
using Polaris.Servico.Validation;
using Polaris.Servico.ViewModels;
using static Polaris.Servico.Exceptions.CustomExceptions;

namespace Polaris.Servico.Services
{
    public class TerceirizadosService : ITerceirizadosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public TerceirizadosService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<RetornoTerceirizadoViewModel> GetTerceirizadosPorServico(string servico)
        {  
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosPorServico(servico);
            if (terceirizados.Count() == 0)
            {
                throw new TerceirizadoNaoEncontradoException("Nenhum resultado encontrado.");
            }
            var terceirizadosDto = _mapper.Map<List<RetornoTerceirizadoViewModel>>(terceirizados);
            return terceirizadosDto;
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados()
        {
            var terceirizados = await _context.TerceirizadoRepository.Get().ToListAsync();
            if (terceirizados is null)
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }
            var terceirizadosDto = _mapper.Map<List<RetornoTerceirizadoViewModel>>(terceirizados);
            return terceirizadosDto;
        }

        public async Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetByParameter(p => p.TerceirizadoUuid == uuid);

            if (terceirizado is null)
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }
            var terceirizadoDto = _mapper.Map<RetornoTerceirizadoViewModel>(terceirizado);
            return terceirizadoDto;
        }

        public async Task<Guid> PostTerceirizado(CadastroTerceirizadoViewModel terceirizadoDto)
        {
            if (await _context.TerceirizadoRepository.GetByParameter(x => x.Empresa == terceirizadoDto.Empresa 
            || x.Cnpj == terceirizadoDto.Cnpj
            || x.Email == terceirizadoDto.Email) is not null)
            {
                throw new CadastrarTerceirizadoException("Terceirizado já existe. Erro ao cadastrar um terceirizado.");
            };

            var terceirizado = _mapper.Map<Models.Terceirizado>(terceirizadoDto);
            StringUtils.ClassToUpper(terceirizado);
            terceirizado.TerceirizadoUuid = Guid.NewGuid();
            terceirizado.Endereco.EnderecoUuid = Guid.NewGuid();
            terceirizado.Status = true;

            if (ValidaCnpj.IsCnpj(terceirizado.Cnpj) is false)
            {
                throw new CadastrarTerceirizadoException("Cnpj inválido. Erro ao cadastrar um terceirizado.");
            };

            if (ValidaTelefone.IsTelefone(terceirizado.Telefone) is false)
            {
                throw new CadastrarTerceirizadoException("Telefone inválido. Erro ao cadastrar um terceirizado.");
            };

            if (ValidaEmail.IsValidEmail(terceirizado.Email) is false)
            {
                throw new CadastrarTerceirizadoException("E-mail inválido. Erro ao cadastrar um terceirizado.");
            }

            _context.TerceirizadoRepository.Add(terceirizado);
            await _context.Commit();

            foreach (var servicoUuid in terceirizadoDto!.ListaServicos!)
            {
                var servico = await _context.ServicoRepository.GetByParameter(x => x.ServicoUuid == servicoUuid);
                terceirizado!.Servicos!.Add(servico);
            }

            await _context.Commit();
            return terceirizado.TerceirizadoUuid;
        }

        public async Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto)
        {

            if (terceirizadoDto.TerceirizadoUuid == Guid.Empty)
            {
                throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
            }

            var terceirizado = await _context.TerceirizadoRepository.GetByParameter(p => p.TerceirizadoUuid == terceirizadoDto.TerceirizadoUuid);

            if (terceirizado == null)
            {
                throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado. Erro ao atualizar o terceirizado.");
            }

            if (terceirizado.TerceirizadoId != 0)
            {
                var terceirizadoMap = _mapper.Map<Models.Terceirizado>(terceirizadoDto);
                StringUtils.ClassToUpper(terceirizadoMap);
                terceirizadoMap.TerceirizadoId = terceirizado.TerceirizadoId;

                _context.TerceirizadoRepository.Update(terceirizadoMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetByParameter(p => p.TerceirizadoUuid == uuid);

            if (terceirizado == null)
            {
                throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado.");
            }

            terceirizado.Status = status;

            _context.TerceirizadoRepository.Update(terceirizado);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaTerceirizadoViewModel>(terceirizado);
        }
    }
}
