using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polaris.Aluguel.Enums;
using Polaris.Aluguel.ExternalServices;
using Polaris.Aluguel.Models;
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
        private readonly IClienteRepository _clienteRepository;
        private readonly IConteinerRepository _conteinerRepository;

        public AlugueisService(IUnityOfWork context, IMapper mapper, IEnderecoExternalService enderecoExternalService, IEnderecoRepository enderecoRepository, IClienteExternalService clienteExternalService, IConteinerExternalService conteinerExternalService, IClienteRepository clienteRepository, IConteinerRepository conteinerRepository)
        {
            _context = context;
            _mapper = mapper;
            _enderecoExternalService = enderecoExternalService;
            _enderecoRepository = enderecoRepository;
            _clienteExternalService = clienteExternalService;
            _conteinerExternalService = conteinerExternalService;
            _clienteRepository = clienteRepository;
            _conteinerRepository = conteinerRepository;
        }

        public async Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueisPorCpf(string cpf)
        {
            var alugueis = _context.AluguelRepository.GetAlugueisPorCpf(cpf);
            if (!alugueis.Any())
            {
                throw new AluguelNaoEncontradoException("Nenhum resultado encontrado.");
            }

            var alugueisDto = _mapper.Map<List<RetornoAluguelViewModel>>(alugueis);
            return alugueisDto;

            //return await ConsultaInformacoesAlugueis(alugueis);
        }

        public async Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueis()
        {
            var alugueis = _context.AluguelRepository.GetAlugueisCompletos();
            if (!alugueis.Any())
            {
                throw new AluguelNaoEncontradoException("Não há aluguéis cadastrados.");
            }

            return await ConsultaInformacoesAlugueis(alugueis);
        }

        public async Task<RetornoAluguelViewModel> GetAluguel(Guid uuid)
        {
            var aluguel = await _context.AluguelRepository.GetAluguel(uuid);
            var aluguelDto = _mapper.Map<RetornoAluguelViewModel>(aluguel);

            aluguelDto.Endereco = await _enderecoExternalService.GetEnderecoAluguel(uuid);

            if (aluguel is null)
            {
                throw new AluguelNaoEncontradoException("Não há aluguéis cadastrados.");
            }
            return aluguelDto;
        }

        public async Task<Guid> PostAluguel(CadastroAluguelViewModel aluguelDto)
        {

            if (aluguelDto.DataInicio < DateTime.UtcNow || aluguelDto.DataDevolucao < DateTime.UtcNow || aluguelDto.DataDevolucao < aluguelDto.DataInicio)
            {
                throw new CadastrarAluguelException("Data inválida");
            }

            var enderecoUuid = await _enderecoExternalService.PostEnderecos(aluguelDto.Endereco);
            aluguelDto.Endereco = null;

            var aluguel = _mapper.Map<Models.Aluguel>(aluguelDto);
            StringUtils.ClassToUpper(aluguel);
            aluguel.AluguelUuid = Guid.NewGuid();
            aluguel.EnderecoId = await _enderecoRepository.GetEnderecoId(enderecoUuid);
            aluguel.ClienteId = _clienteRepository.GetClienteId(aluguelDto.ClienteUuid.Value);
            aluguel.Status = true;
            aluguel.EstadoAluguel = EstadoAluguel.Solicitado;

            //calculo

            _context.AluguelRepository.Add(aluguel);
            await _context.Commit();

            aluguel.Conteineres = new List<Models.Conteiner>();
            foreach (var conteinerUuid in aluguelDto.ConteineresUuid)
            {
                var conteiner = _mapper.Map<Models.Conteiner>(await _conteinerExternalService.GetConteineres(conteinerUuid));
                (conteiner.ConteinerId, conteiner.CategoriaConteinerId, conteiner.TipoConteinerId) = 
                    _conteinerRepository.GetConteinerIds(conteiner.ConteinerUuid, conteiner.CategoriaConteiner.CategoriaConteinerUuid, conteiner.TipoConteiner.TipoConteinerUuid);
                conteiner.TipoConteiner = null;
                conteiner.CategoriaConteiner = null;
                aluguel.Conteineres.Add(conteiner);
            }

            await _context.Commit();
            return aluguel.AluguelUuid;
        }

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

        private async Task<IEnumerable<RetornoAluguelViewModel>> ConsultaInformacoesAlugueis(IEnumerable<Models.Aluguel> alugueis)
        {
            List<RetornoAluguelViewModel> alugueisDto = new();
            foreach (var aluguel in alugueis)
            {
                var aluguelDto = _mapper.Map<RetornoAluguelViewModel>(aluguel);
                aluguelDto.Endereco = await _enderecoExternalService.GetEnderecoAluguel(aluguel.AluguelUuid);
                aluguelDto.Cliente = await _clienteExternalService.GetClienteAluguel(aluguel.AluguelUuid);
                aluguelDto.Conteineres = await _conteinerExternalService.GetConteineresAluguel(aluguel.AluguelUuid);
                alugueisDto.Add(aluguelDto);
            }
            return alugueisDto;
        }

        private static int CalcularDiasEntreDatas(DateTime dataInicial, DateTime dataFinal)
        {
            TimeSpan diferenca = dataFinal - dataInicial;
            return diferenca.Days;
        }

        private static int CalcularMesesEntreDatas(DateTime dataInicial, DateTime dataFinal)
        {
            int meses = ((dataFinal.Year - dataInicial.Year) * 12) + dataFinal.Month - dataInicial.Month;

            if (dataFinal.Day < dataInicial.Day)
                meses--;

            return meses;
        }
    }
}
