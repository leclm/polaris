﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Endereco.DTOs;
using Polaris.Endereco.Repository;
using Polaris.Endereco.Utils;
using static Polaris.Endereco.Exceptions.CustomExceptions;

namespace Polaris.Endereco.Services
{
    public class EnderecosService : IEnderecosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public EnderecosService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RetornoEnderecoViewModel>> GetEnderecos()
        {
            var enderecos = await _context.EnderecoRepository.Get().ToListAsync();
            if (enderecos is null)
            {
                throw new EnderecoNaoEncontradoException("Não há endereços cadastrados.");
            }
            var enderecosDto = _mapper.Map<List<RetornoEnderecoViewModel>>(enderecos);
            return enderecosDto;
        }

        public async Task<RetornoEnderecoViewModel> GetEndereco(Guid uuid)
        {
            var endereco = await _context.EnderecoRepository.GetById(p => p.EnderecoUuid == uuid);

            if (endereco is null)
            {
                throw new EnderecoNaoEncontradoException("Endereço não encontrado.");
            }
            var enderecoDto = _mapper.Map<RetornoEnderecoViewModel>(endereco);
            return enderecoDto;
        }

        public async Task<Guid> PostEndereco(CadastroEnderecoViewModel enderecoDto)
        {
            var endereco = _mapper.Map<Models.Endereco>(enderecoDto);
            StringUtils.ClassToUpper(endereco);
            endereco.EnderecoUuid = Guid.NewGuid();
            endereco.Status = true;

            if (endereco is null)
            {
                throw new CadastrarEnderecoException("Endereço inválido. Erro ao cadastrar um endereço.");
            }

            _context.EnderecoRepository.Add(endereco);
            await _context.Commit();
            return endereco.EnderecoUuid;
        }

        public async Task PutEndereco(AtualizaEnderecoViewModel enderecoDto)
        {
            
            if (enderecoDto.EnderecoUuid == Guid.Empty)
            {
                throw new AtualizarEnderecoException("Endereço inválido. Erro ao atualizar o endereço.");
            }

            var endereco = await _context.EnderecoRepository.GetById(p => p.EnderecoUuid == enderecoDto.EnderecoUuid);

            if (endereco.EnderecoId != 0)
            {
                var enderecoMap = _mapper.Map<Models.Endereco>(enderecoDto);
                StringUtils.ClassToUpper(enderecoMap);
                enderecoMap.EnderecoId = endereco.EnderecoId;

                _context.EnderecoRepository.Update(enderecoMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarEnderecoException("Endereço inválido. Erro ao atualizar o endereço.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var endereco = await _context.EnderecoRepository.GetById(p => p.EnderecoUuid == uuid);

            if (endereco == null)
            {
                throw new EnderecoNaoEncontradoException("Endereço não encontrado.");
            }

            endereco.Status = status;

            _context.EnderecoRepository.Update(endereco);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaEnderecoViewModel>(endereco);
        }
    }
}