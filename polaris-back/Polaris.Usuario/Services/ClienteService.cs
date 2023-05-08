using AutoMapper;
using Polaris.Usuario.ExternalServices;
using Polaris.Usuario.Models;
using Polaris.Usuario.Repository;
using Polaris.Usuario.Utils;
using Polaris.Usuario.Validation;
using Polaris.Usuario.ViewModels;
using static Polaris.Usuario.Exceptions.CustomExceptions;

namespace Polaris.Usuario.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly IEnderecoExternalService _enderecoExternalService;
        private readonly ILoginService _loginService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ILoginRepository _loginRepository;

        public ClienteService(IUnityOfWork context, IMapper mapper, IEnderecoExternalService enderecoExternalService, IEnderecoRepository enderecoRepository, ILoginRepository loginRepository, ILoginService loginService)
        {
            _context = context;
            _mapper = mapper;
            _enderecoExternalService = enderecoExternalService;
            _enderecoRepository = enderecoRepository;
            _loginRepository = loginRepository;
            _loginService = loginService;
        }

        public async Task<IEnumerable<RetornoClienteViewModel>> GetClientes()
        {
            var clientes = _context.ClienteRepository.GetClientesCompleto();
            if (!clientes.Any())
            {
                throw new ClienteNaoEncontradoException("Não há clientes cadastrados.");
            }

            return await ConsultaEnderecosClientes(clientes);
        }

        public async Task<IEnumerable<RetornoClienteViewModel>> GetClientesAtivos()
        {
            var clientes = _context.ClienteRepository.GetClientesAtivosCompleto();
            if (!clientes.Any())
            {
                throw new ClienteNaoEncontradoException("Não há clientes ativos.");
            }
            return await ConsultaEnderecosClientes(clientes);
        }

        public async Task<RetornoClienteViewModel> GetCliente(Guid uuid)
        {
            var cliente = await _context.ClienteRepository.GetCliente(uuid);
            cliente.Endereco = await _enderecoExternalService.GetEnderecoCliente(uuid);

            if (cliente is null)
            {
                throw new ClienteNaoEncontradoException("Não há clientes cadastrados.");
            }
            var clienteDto = _mapper.Map<RetornoClienteViewModel>(cliente);
            return clienteDto;
        }

        public async Task<Guid> PostCliente(CadastroClienteViewModel clienteDto)
        {
            if (await _context.ClienteRepository.GetByParameter(x => x.Cpf == clienteDto.Cpf
            || x.Email == clienteDto.Email) is not null)
            {
                throw new CadastrarClienteException("Cliente já existe. Erro ao cadastrar um cliente.");
            }

            var enderecoUuid = await _enderecoExternalService.PostEnderecos(clienteDto.Endereco);
            clienteDto.Endereco = null;

            var loginUuid = await _loginService.CadastrarLogin(new CadastroLoginViewModel(clienteDto));

            var cliente = _mapper.Map<Cliente>(clienteDto);
            StringUtils.ClassToUpper(cliente);
            cliente.ClienteUuid = Guid.NewGuid();
            cliente.EnderecoId = await _enderecoRepository.GetEnderecoId(enderecoUuid);
            cliente.LoginId = await _loginRepository.GetLoginId(loginUuid);
            cliente.Status = true;

            if (ValidaCpf.IsCpf(cliente.Cpf) is false)
            {
                throw new CadastrarClienteException("CPF inválido. Erro ao cadastrar um cliente.");
            };

            //if (ValidaTelefone.IsTelefone(terceirizado.Telefone) is false)
            //{
            //    throw new CadastrarClienteException("Telefone inválido. Erro ao cadastrar um terceirizado.");
            //};

            if (ValidaEmail.IsValidEmail(cliente.Email) is false)
            {
                throw new CadastrarClienteException("E-mail inválido. Erro ao cadastrar um cliente.");
            }

            _context.ClienteRepository.Add(cliente);
          
            await _context.Commit();
            return cliente.ClienteUuid;
        }

        public async Task PutCliente(AtualizaClienteViewModel clienteDto)
        {
            if (clienteDto.ClienteUuid == Guid.Empty)
            {
                throw new AtualizarClienteException("Cliente inválido. Erro ao atualizar.");
            }

            //if (ValidaTelefone.IsTelefone(terceirizado.Telefone) is false)
            //{
            //    throw new CadastrarClienteException("Telefone inválido. Erro ao cadastrar um terceirizado.");
            //};

            var cliente = await _context.ClienteRepository.GetCliente(clienteDto.ClienteUuid);

            if (cliente == null || cliente.ClienteId == 0)
            {
                throw new AtualizarClienteException("Cliente não encontrado. Erro ao atualizar.");
            }

            await _enderecoExternalService.PutEnderecos(clienteDto.Endereco);
            clienteDto.Endereco = null;
          
            var clienteBase = await _context.ClienteRepository.GetByParameter(p => p.ClienteUuid == clienteDto.ClienteUuid);
            clienteBase.Nome = clienteDto.Nome;
            clienteBase.Sobrenome = clienteDto.Sobrenome;
            clienteBase.Telefone = clienteDto.Telefone;
            StringUtils.ClassToUpper(clienteBase);
            _context.ClienteRepository.Update(clienteBase);
            await _context.Commit();
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var cliente = await _context.ClienteRepository.GetByParameter(p => p.ClienteUuid == uuid);

            if (cliente == null)
            {
                throw new ClienteNaoEncontradoException("Cliente não encontrado.");
            }

            cliente.Status = status;

            _context.ClienteRepository.Update(cliente);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaClienteViewModel>(cliente);
        }

        private async Task<IEnumerable<RetornoClienteViewModel>> ConsultaEnderecosClientes(IEnumerable<Cliente> clientes)
        {
            List<RetornoClienteViewModel> clientesDto = new();
            foreach (var cliente in clientes)
            {
                cliente.Endereco = await _enderecoExternalService.GetEnderecoCliente(cliente.ClienteUuid);
                clientesDto.Add(_mapper.Map<RetornoClienteViewModel>(cliente));
            }
            return clientesDto;
        }
    }
}
