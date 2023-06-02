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
    public class GerenteService : IGerenteService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly IEnderecoExternalService _enderecoExternalService;
        private readonly ILoginService _loginService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ILoginRepository _loginRepository;

        public GerenteService(IUnityOfWork context, IMapper mapper, IEnderecoExternalService enderecoExternalService, ILoginService loginService, IEnderecoRepository enderecoRepository, ILoginRepository loginRepository)
        {
            _context = context;
            _mapper = mapper;
            _enderecoExternalService = enderecoExternalService;
            _loginService = loginService;
            _enderecoRepository = enderecoRepository;
            _loginRepository = loginRepository;
        }

        public async Task<IEnumerable<RetornoGerenteViewModel>> GetGerentes(string token)
        {
            var gerentes = _context.GerenteRepository.GenteGerentesCompleto();
            if (!gerentes.Any())
            {
                throw new GerenteNaoEncontradoException("Não há gerentes cadastrados.");
            }

            return await ConsultaEnderecosGerentes(gerentes, token);
        }

        public async Task<IEnumerable<RetornoGerenteViewModel>> GetGerentesAtivos(string token)
        {
            var gerentes = _context.GerenteRepository.GetGerentesAtivosCompleto();
            if (!gerentes.Any())
            {
                throw new GerenteNaoEncontradoException("Não há gerentes ativos.");
            }
            return await ConsultaEnderecosGerentes(gerentes, token);
        }

        public async Task<RetornoGerenteViewModel> GetGerente(Guid uuid, string token)
        {
            var gerente = await _context.GerenteRepository.GetGerente(uuid);
            gerente.Endereco = await _enderecoExternalService.GetEnderecoGerente(uuid, token);

            if (gerente is null)
            {
                throw new GerenteNaoEncontradoException("Não há gerentes cadastrados.");
            }
            var gerenteDto = _mapper.Map<RetornoGerenteViewModel>(gerente);
            return gerenteDto;
        }

        public async Task<Guid> PostGerente(CadastroGerenteViewModel gerenteDto, string token)
        {
            if (await _context.GerenteRepository.GetByParameter(x => x.Cnpj == gerenteDto.Cnpj
            || x.Email == gerenteDto.Email) is not null)
            {
                throw new CadastrarGerenteException("Gerente já existe. Erro ao cadastrar um gerente.");
            }

            var enderecoUuid = await _enderecoExternalService.PostEnderecos(gerenteDto.Endereco, token);
            gerenteDto.Endereco = null;

            var loginUuid = await _loginService.CadastrarLogin(new CadastroLoginViewModel(gerenteDto));

            var gerente = _mapper.Map<Gerente>(gerenteDto);
            StringUtils.ClassToUpper(gerente);
            gerente.GerenteUuid = Guid.NewGuid();
            gerente.EnderecoId = await _enderecoRepository.GetEnderecoId(enderecoUuid);
            gerente.LoginId = await _loginRepository.GetLoginId(loginUuid);
            gerente.Status = true;

            if (ValidaCnpj.IsCnpj(gerente.Cnpj) is false)
            {
                throw new CadastrarGerenteException("CNPJ inválido. Erro ao cadastrar um gerente.");
            };

            //if (ValidaTelefone.IsTelefone(gerenteDto.Telefone) is false)
            //{
            //    throw new CadastrarGerenteException("Telefone inválido. Erro ao cadastrar um gerente.");
            //};

            if (ValidaEmail.IsValidEmail(gerente.Email) is false)
            {
                throw new CadastrarGerenteException("E-mail inválido. Erro ao cadastrar um gerente.");
            }

            _context.GerenteRepository.Add(gerente);

            await _context.Commit();
            return gerente.GerenteUuid;
        }

        public async Task PutGerente(AtualizaGerenteViewModel gerenteDto, string token)
        {
            if (gerenteDto.GerenteUuid == Guid.Empty)
            {
                throw new AtualizarGerenteException("Gerente inválido. Erro ao atualizar.");
            }

            //if (ValidaTelefone.IsTelefone(gerenteDto.Telefone) is false)
            //{
            //    throw new CadastrarGerenteException("Telefone inválido. Erro ao cadastrar um gerente.");
            //};

            var gerente = await _context.GerenteRepository.GetGerente(gerenteDto.GerenteUuid);

            if (gerente == null || gerente.GerenteId == 0)
            {
                throw new AtualizarGerenteException("Gerente não encontrado. Erro ao atualizar.");
            }

            await _enderecoExternalService.PutEnderecos(gerenteDto.Endereco, token);
            gerenteDto.Endereco = null;

            var gerenteBase = await _context.GerenteRepository.GetByParameter(p => p.GerenteUuid == gerenteDto.GerenteUuid);
            gerenteBase.Empresa = gerenteDto.Empresa;
            gerenteBase.Cnpj = gerenteDto.Cnpj;
            gerenteBase.Telefone = gerenteDto.Telefone;
            StringUtils.ClassToUpper(gerenteBase);
            _context.GerenteRepository.Update(gerenteBase);
            await _context.Commit();
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var gerente = await _context.GerenteRepository.GetByParameter(p => p.GerenteUuid == uuid);

            if (gerente == null)
            {
                throw new GerenteNaoEncontradoException("Gerente não encontrado.");
            }

            gerente.Status = status;

            _context.GerenteRepository.Update(gerente);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaGerenteViewModel>(gerente);
        }

        private async Task<IEnumerable<RetornoGerenteViewModel>> ConsultaEnderecosGerentes(IEnumerable<Gerente> gerentes, string token)
        {
            List<RetornoGerenteViewModel> gerentesDto = new();
            foreach (var gerente in gerentes)
            {
                gerente.Endereco = await _enderecoExternalService.GetEnderecoGerente(gerente.GerenteUuid, token);
                gerentesDto.Add(_mapper.Map<RetornoGerenteViewModel>(gerente));
            }
            return gerentesDto;
        }
    }
}
