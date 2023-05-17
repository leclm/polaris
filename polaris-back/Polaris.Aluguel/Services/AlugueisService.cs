using AutoMapper;
using Polaris.Aluguel.Enums;
using Polaris.Aluguel.ExternalServices;
using Polaris.Aluguel.Repository;
using Polaris.Aluguel.Utils;
using Polaris.Aluguel.ViewModels;
using static Polaris.Aluguel.Exceptions.CustomExceptions;

namespace Polaris.Aluguel.Services
{
    public class AlugueisService : IAlugueisService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly IEnderecoExternalService _enderecoExternalService;
        private readonly IClienteExternalService _clienteExternalService;
        private readonly IConteinerExternalService _conteinerExternalService;
        private readonly IEnderecoRepository _enderecoRepository;

        public AlugueisService(IUnityOfWork context, IMapper mapper, IEnderecoExternalService enderecoExternalService, IEnderecoRepository enderecoRepository, IClienteExternalService clienteExternalService, IConteinerExternalService conteinerExternalService)
        {
            _context = context;
            _mapper = mapper;
            _enderecoExternalService = enderecoExternalService;
            _enderecoRepository = enderecoRepository;
            _clienteExternalService = clienteExternalService;
            _conteinerExternalService = conteinerExternalService;
        }

        public async Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueisPorCpf(string cpf)
        {
            var alugueis = _context.AluguelRepository.GetAlugueisPorCpf(cpf);
            if (!alugueis.Any())
            {
                throw new AluguelNaoEncontradoException("Nenhum resultado encontrado.");
            }

            return await ConsultaEnderecosAlugueis(alugueis);
        }

        public async Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueis()
        {
            var alugueis = _context.AluguelRepository.GetAlugueisCompletos();
            if (!alugueis.Any())
            {
                throw new AluguelNaoEncontradoException("Não há aluguéis cadastrados.");
            }

            return await ConsultaEnderecosAlugueis(alugueis);
        }

        //public async Task<IEnumerable<RetornoAluguelViewModel>> GetTerceirizadosAtivos()
        //{
        //    var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosAtivosCompleto();
        //    if (!terceirizados.Any())
        //    {
        //        throw new TerceirizadoNaoEncontradoException("Não há terceirizados ativos.");
        //    }
        //    return await ConsultaEnderecosTerceirizados(terceirizados);
        //}

        public async Task<RetornoAluguelViewModel> GetAluguel(Guid uuid)
        {
            var aluguel = await _context.AluguelRepository.GetAluguel(uuid);
            aluguel.Endereco = await _enderecoExternalService.GetEnderecoAluguel(uuid);

            if (aluguel is null)
            {
                throw new AluguelNaoEncontradoException("Não há aluguéis cadastrados.");
            }
            var aluguelDto = _mapper.Map<RetornoAluguelViewModel>(aluguel);
            return aluguelDto;
        }

        public async Task<Guid> PostAluguel(CadastroAluguelViewModel aluguelDto)
        {
            if (await _context.AluguelRepository.GetByParameter(x => x.Cliente.Cpf == aluguelDto.Cliente.Cpf
              || x.Endereco.Cep == aluguelDto.Endereco.Cep
              || x.Endereco.Numero == aluguelDto.Endereco.Numero
              || x.Endereco.Logradouro == aluguelDto.Endereco.Logradouro
              || x.Conteineres == aluguelDto.Conteineres) is not null)
            {
                throw new CadastrarAluguelException("Aluguel já existe. Erro ao cadastrar um aluguel.");
            };

            var enderecoUuid = await _enderecoExternalService.PostEnderecos(aluguelDto.Endereco);
            aluguelDto.Endereco = null;

            var aluguel = _mapper.Map<Models.Aluguel>(aluguelDto);
            StringUtils.ClassToUpper(aluguel);
            aluguel.AluguelUuid = Guid.NewGuid();
            aluguel.EnderecoId = await _enderecoRepository.GetEnderecoId(enderecoUuid);
            aluguel.Status = true;

            _context.AluguelRepository.Add(aluguel);
            await _context.Commit();
            return aluguel.AluguelUuid;
        }

        //public async Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto)
        //{
        //    if (terceirizadoDto.TerceirizadoUuid == Guid.Empty)
        //    {
        //        throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
        //    }

        //    var terceirizado = await _context.TerceirizadoRepository.GetTerceirizado(terceirizadoDto.TerceirizadoUuid);

        //    if (terceirizado == null || terceirizado.TerceirizadoId == 0)
        //    {
        //        throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado. Erro ao atualizar o terceirizado.");
        //    }

        //    await _enderecoExternalService.PutEnderecos(terceirizadoDto.Endereco);
        //    terceirizadoDto.Endereco = null;

        //    if (ValidaCnpj.IsCnpj(terceirizadoDto.Cnpj) is false)
        //    {
        //        throw new AtualizarTerceirizadoException("Cnpj inválido. Erro ao editar um terceirizado.");
        //    };

        //    //if (ValidaTelefone.IsTelefone(terceirizadoDto.Telefone) is false)
        //    //{
        //    //    throw new AtualizarTerceirizadoException("Telefone inválido. Erro ao editar um terceirizado.");
        //    //};

        //    if (ValidaEmail.IsValidEmail(terceirizadoDto.Email) is false)
        //    {
        //        throw new AtualizarTerceirizadoException("E-mail inválido. Erro ao editar um terceirizado.");
        //    }

        //    List<Models.Servico> servicos = new();
        //    if (terceirizadoDto.ListaServicos is not null || terceirizadoDto.ListaServicos!.Any())
        //    {
        //        foreach (var servicoUuid in terceirizadoDto.ListaServicos!)
        //        {
        //            servicos.Add(await _servicoRepository.GetByParameter(x => x.ServicoUuid == servicoUuid));
        //        }
        //    }
        //    else
        //    {
        //        throw new AtualizarTerceirizadoException("Serviço Inválido. Erro ao atualizar o terceirizado.");
        //    }


        //    terceirizado.Cnpj = terceirizadoDto.Cnpj;
        //    terceirizado.Empresa = terceirizadoDto.Empresa;
        //    terceirizado.Email = terceirizadoDto.Email;
        //    terceirizado.Telefone = terceirizadoDto.Telefone;
        //    StringUtils.ClassToUpper(terceirizado);
        //    _context.TerceirizadoRepository.Update(terceirizado);
        //    await _context.Commit();

        //    _context.TerceirizadoRepository.LimpaServicos(terceirizado);

        //    terceirizado.Servicos = servicos;
        //    await _context.Commit();

        //}

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var aluguel = await _context.AluguelRepository.GetByParameter(p => p.AluguelUuid == uuid);

            if (aluguel == null)
            {
                throw new AluguelNaoEncontradoException("Aluguel não encontrado.");
            }

            aluguel.Status = status;

            _context.AluguelRepository.Update(aluguel);
            await _context.Commit();
        }

        public async Task AlterarEstadoAluguel(Guid uuid, EstadoAluguel estado)
        {
            var aluguel = await _context.AluguelRepository.GetByParameter(p => p.AluguelUuid == uuid);

            if (aluguel == null)
            {
                throw new AluguelNaoEncontradoException("Não há aluguéis cadastrados.");
            }

            aluguel.EstadoAluguel = estado;

            _context.AluguelRepository.Update(aluguel);
            await _context.Commit();
        }

        private async Task<IEnumerable<RetornoAluguelViewModel>> ConsultaEnderecosAlugueis(IEnumerable<Models.Aluguel> alugueis)
        {
            List<RetornoAluguelViewModel> alugueisDto = new();
            foreach (var aluguel in alugueis)
            {
                aluguel.Endereco = await _enderecoExternalService.GetEnderecoAluguel(aluguel.AluguelUuid);
                alugueisDto.Add(_mapper.Map<RetornoAluguelViewModel>(aluguel));
            }
            return alugueisDto;
        }

        private async Task<IEnumerable<RetornoAluguelViewModel>> ConsultaClientesAlugueis(IEnumerable<Models.Aluguel> alugueis)
        {
            List<RetornoAluguelViewModel> alugueisDto = new();
            foreach (var aluguel in alugueis)
            {
                aluguel.Cliente = await _clienteExternalService.GetClienteAluguel(aluguel.AluguelUuid);
                alugueisDto.Add(_mapper.Map<RetornoAluguelViewModel>(aluguel));
            }
            return alugueisDto;
        }

        private async Task<IEnumerable<RetornoAluguelViewModel>> ConsultaConteineressAlugueis(IEnumerable<Models.Aluguel> alugueis)
        {
            List<RetornoAluguelViewModel> alugueisDto = new();
            foreach (var aluguel in alugueis)
            {
                aluguel.Conteineres = await _conteinerExternalService.GetConteineresAluguel(aluguel.AluguelUuid);
                alugueisDto.Add(_mapper.Map<RetornoAluguelViewModel>(aluguel));
            }
            return alugueisDto;
        }
    }
}
