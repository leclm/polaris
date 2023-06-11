﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polaris.Servico.ExternalServices;
using Polaris.Servico.Models;
using Polaris.Servico.Repository;
using Polaris.Servico.Utils;
using Polaris.Servico.Validation;
using Polaris.Servico.ViewModels;
using System;
using System.Collections.ObjectModel;
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

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosPorServico(string servico, string token)
        {  
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosPorServico(servico);
            if (!terceirizados.Any())
            {
                throw new TerceirizadoNaoEncontradoException("Nenhum resultado encontrado.");
            }

            return await ConsultaEnderecosTerceirizados(terceirizados, token);
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados(string token)
        {
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosCompleto();
            if (!terceirizados.Any())
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }

           return await ConsultaEnderecosTerceirizados(terceirizados, token);
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosAtivos(string token)
        {
            var terceirizados = _context.TerceirizadoRepository.GetTerceirizadosAtivosCompleto();
            if (!terceirizados.Any())
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados ativos.");
            }
            return await ConsultaEnderecosTerceirizados(terceirizados, token);
        }

        public async Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid, string token)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetTerceirizado(uuid);
            terceirizado.Endereco = await _enderecoExternalService.GetEnderecoTerceirizado(uuid, token);

            if (terceirizado is null)
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }
            var terceirizadoDto = _mapper.Map<RetornoTerceirizadoViewModel>(terceirizado);
            return terceirizadoDto;
        }

        public async Task<Guid> PostTerceirizado(CadastroTerceirizadoViewModel terceirizadoDto, string token)
        {
            if (await _context.TerceirizadoRepository.GetByParameter(x => x.Empresa == terceirizadoDto.Empresa 
            || x.Cnpj == terceirizadoDto.Cnpj
            || x.Email == terceirizadoDto.Email) is not null)
            {
                throw new CadastrarTerceirizadoException("Terceirizado já existe. Erro ao cadastrar um terceirizado.");
            };

            var enderecoUuid = await _enderecoExternalService.PostEnderecos(terceirizadoDto.Endereco, token);
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

        public async Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto, string token)
        {
            if (terceirizadoDto.TerceirizadoUuid == Guid.Empty)
            {
                throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
            }

            var terceirizado = await _context.TerceirizadoRepository.GetTerceirizado(terceirizadoDto.TerceirizadoUuid);

            if (terceirizado == null || terceirizado.TerceirizadoId == 0)
            {
                throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado. Erro ao atualizar o terceirizado.");
            }

            await _enderecoExternalService.PutEnderecos(terceirizadoDto.Endereco, token);
            terceirizadoDto.Endereco = null;

            if (ValidaCnpj.IsCnpj(terceirizadoDto.Cnpj) is false)
            {
                throw new AtualizarTerceirizadoException("Cnpj inválido. Erro ao editar um terceirizado.");
            };

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

           
            terceirizado.Cnpj = terceirizadoDto.Cnpj;
            terceirizado.Empresa = terceirizadoDto.Empresa;
            terceirizado.Email = terceirizadoDto.Email;
            terceirizado.Telefone = terceirizadoDto.Telefone;
            StringUtils.ClassToUpper(terceirizado);
            _context.TerceirizadoRepository.Update(terceirizado);
            await _context.Commit();

            _context.TerceirizadoRepository.LimpaServicos(terceirizado);

            terceirizado.Servicos = servicos;
            await _context.Commit();

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

        private async Task<IEnumerable<RetornoTerceirizadoViewModel>> ConsultaEnderecosTerceirizados(IEnumerable<Terceirizado> terceirizados, string token)
        {
            List<RetornoTerceirizadoViewModel> terceirizadosDto = new();
            foreach (var terceirizado in terceirizados)
            {
                terceirizado.Endereco = await _enderecoExternalService.GetEnderecoTerceirizado(terceirizado.TerceirizadoUuid, token);
                terceirizadosDto.Add(_mapper.Map<RetornoTerceirizadoViewModel>(terceirizado));
            }
            return terceirizadosDto;
        }

        public async Task<RetornoTerceirizadoViewModel> GetTerceirizadoByPrestacaoDeServico(Guid uuidPrestacaoDeServico, string token)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetTerceirizadoByPrestacaoDeServico(uuidPrestacaoDeServico);
            terceirizado.Endereco = await _enderecoExternalService.GetEnderecoTerceirizado(terceirizado.TerceirizadoUuid, token);

            if (terceirizado is null)
            {
                throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado.");
            }
            var terceirizadoDto = _mapper.Map<RetornoTerceirizadoViewModel>(terceirizado);
            return terceirizadoDto;
        }
    }
}
