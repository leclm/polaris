using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.ExternalServices;
using Polaris.Servico.Models;
using Polaris.Servico.Repository;
using Polaris.Servico.Utils;
using Polaris.Servico.Validation;
using Polaris.Servico.ViewModels;
using System;
using static Polaris.Servico.Exceptions.CustomExceptions;

namespace Polaris.Servico.Services
{
    public class TerceirizadosService : ITerceirizadosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly IEnderecoExternalService _enderecoExternalService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IServicoRepository _servicoRepository;

        public TerceirizadosService(IUnityOfWork context, IMapper mapper, IEnderecoExternalService enderecoExternalService, IEnderecoRepository enderecoRepository, IServicoRepository servicoRepository)
        {
            _context = context;
            _mapper = mapper;
            _enderecoExternalService = enderecoExternalService;
            _enderecoRepository = enderecoRepository;
            _servicoRepository = servicoRepository;
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosPorServico(string servico)
        {  
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosPorServico(servico);
            if (!terceirizados.Any())
            {
                throw new TerceirizadoNaoEncontradoException("Nenhum resultado encontrado.");
            }

            return await ConsultaEnderecosTerceirizados(terceirizados);
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados()
        {
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosCompleto();
            if (!terceirizados.Any())
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }

           return await ConsultaEnderecosTerceirizados(terceirizados);
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosAtivos()
        {
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosAtivosCompleto();
            if (!terceirizados.Any())
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados ativos.");
            }
            return await ConsultaEnderecosTerceirizados(terceirizados);
        }

        public async Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetTerceirizado(uuid);
            terceirizado.Endereco = await _enderecoExternalService.GetEnderecoTerceirizado(uuid);

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

            var enderecoUuid = await _enderecoExternalService.PostEnderecos(terceirizadoDto.Endereco);
            terceirizadoDto.Endereco = null;

            var terceirizado = _mapper.Map<Models.Terceirizado>(terceirizadoDto);
            StringUtils.ClassToUpper(terceirizado);
            terceirizado.TerceirizadoUuid = Guid.NewGuid();
            terceirizado.EnderecoId = await _enderecoRepository.GetEnderecoId(enderecoUuid);
            terceirizado.Status = true;

            if (ValidaCnpj.IsCnpj(terceirizado.Cnpj) is false)
            {
                throw new CadastrarTerceirizadoException("Cnpj inválido. Erro ao cadastrar um terceirizado.");
            };

            //if (ValidaTelefone.IsTelefone(terceirizado.Telefone) is false)
            //{
            //    throw new CadastrarTerceirizadoException("Telefone inválido. Erro ao cadastrar um terceirizado.");
            //};

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
            //StringUtils.ClassToUpper(terceirizadoDto);

            if (terceirizadoDto.TerceirizadoUuid == Guid.Empty)
            {
                throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
            }

            var terceirizado = await _context.TerceirizadoRepository.GetByParameter(p => p.TerceirizadoUuid == terceirizadoDto.TerceirizadoUuid);

            if (terceirizado == null)
            {
                throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado. Erro ao atualizar o terceirizado.");
            }

            await _enderecoExternalService.PutEnderecos(terceirizadoDto.Endereco);
            terceirizadoDto.Endereco = null;

            if (ValidaCnpj.IsCnpj(terceirizadoDto.Cnpj) is false)
            {
                throw new AtualizarTerceirizadoException("Cnpj inválido. Erro ao editar um terceirizado.");
            };

            //if (ValidaTelefone.IsTelefone(terceirizadoDto.Telefone) is false)
            //{
            //    throw new AtualizarTerceirizadoException("Telefone inválido. Erro ao editar um terceirizado.");
            //};

            if (ValidaEmail.IsValidEmail(terceirizadoDto.Email) is false)
            {
                throw new AtualizarTerceirizadoException("E-mail inválido. Erro ao editar um terceirizado.");
            }

            List<Models.Servico> servicos = new();
            if (terceirizadoDto.ListaServicos is not null || terceirizadoDto.ListaServicos!.Any())
            {
                foreach (var servicoUuid in terceirizadoDto.ListaServicos!)
                {
                    servicos.Add(await _servicoRepository.GetByParameter(x => x.ServicoUuid == servicoUuid));
                }
            }
            else
            {
                throw new AtualizarTerceirizadoException("Serviço Inválido. Erro ao atualizar o terceirizado.");
            }

            if (terceirizado.TerceirizadoId != 0)
            {
                var terceirizadoMap = _mapper.Map<Terceirizado>(terceirizadoDto);
                var terceirizadoBase = await _context.TerceirizadoRepository.GetByParameter(p => p.TerceirizadoUuid == terceirizadoMap.TerceirizadoUuid);
                terceirizadoMap.Status = terceirizadoBase.Status;
                terceirizadoMap.TerceirizadoId = terceirizado.TerceirizadoId;
                terceirizadoMap.EnderecoId = terceirizado.EnderecoId;
                terceirizadoMap.Servicos = servicos;
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

        private async Task<IEnumerable<RetornoTerceirizadoViewModel>> ConsultaEnderecosTerceirizados(IEnumerable<Terceirizado> terceirizados)
        {
            List<RetornoTerceirizadoViewModel> terceirizadosDto = new();
            foreach (var terceirizado in terceirizados)
            {
                terceirizado.Endereco = await _enderecoExternalService.GetEnderecoTerceirizado(terceirizado.TerceirizadoUuid);
                terceirizadosDto.Add(_mapper.Map<RetornoTerceirizadoViewModel>(terceirizado));
            }
            return terceirizadosDto;
        }
    }
}
