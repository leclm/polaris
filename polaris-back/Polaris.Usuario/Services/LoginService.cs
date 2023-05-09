﻿using AutoMapper;
using Polaris.Usuario.Models;
using Polaris.Usuario.Repository;
using Polaris.Usuario.Utils;
using Polaris.Usuario.ViewModels;
using static Polaris.Usuario.Exceptions.CustomExceptions;

namespace Polaris.Usuario.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public LoginService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetornoLoginViewModel> Logar(CadastroLoginViewModel loginDto)
        {
            var login = await _context.LoginRepository.GetByParameter(x => x.Usuario == loginDto.Usuario && x.Senha == loginDto.Senha);

            if (login == null || login.LoginId == 0)
            {
                throw new LoginNaoEncontradoException("Usuário/senha inválidos. Erro ao logar.");
            }

            StringUtils.ClassToUpper(login);

            return new RetornoLoginViewModel()
            {
                Usuario = loginDto.Usuario,
                IsGerente = await IsGerente(login.LoginId),
                LoginUuid = login.LoginUuid,
                Status = login.Status
            };
        }

        private async Task<bool> IsGerente(int idLogin)
        {
            var gerente = await _context.GerenteRepository.GetByParameter(p => p.LoginId == idLogin);
            if (gerente == null || gerente.GerenteId == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Guid> CadastrarLogin(CadastroLoginViewModel loginDto)
        {
            if(await _context.LoginRepository.GetByParameter(x => x.Usuario == loginDto.Usuario) is not null)
            {
                throw new CadastrarLoginException("Usuário já existe. Erro ao cadastrar.");
            }

            var login = _mapper.Map<Models.Login>(loginDto);

            if (login is null)
            {
                throw new CadastrarLoginException("Usuário/senha inválidos. Erro ao cadastrar.");
            }

            StringUtils.ClassToUpper(login);
            login.LoginUuid = Guid.NewGuid();
            login.Status = true;

            _context.LoginRepository.Add(login);
            await _context.Commit();

            return login.LoginUuid;
        }

        public async Task PutLogin(AtualizaLoginViewModel loginDto)
        {

            if (loginDto.LoginUuid == Guid.Empty || String.IsNullOrEmpty(loginDto.ToString()))
            {
                throw new AtualizarLoginException("Login inválido. Erro ao atualizar.");
            }

            var login = await _context.LoginRepository.GetByParameter(p => p.LoginUuid == loginDto.LoginUuid);

            if (login != null && login.LoginId != 0)
            {
                login.Usuario = loginDto.Usuario;
                login.Senha = loginDto.Senha;
                StringUtils.ClassToUpper(login);

                _context.LoginRepository.Update(login);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarLoginException("Usuário/senha inválidos. Erro ao cadastrar.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var login = await _context.LoginRepository.GetByParameter(p => p.LoginUuid == uuid);

            if (login == null)
            {
                throw new LoginNaoEncontradoException("Login não encontrado.");
            }

            login.Status = status;

            _context.LoginRepository.Update(login);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaLoginViewModel>(login);
        }

        public async Task AlterarSenha(AlteraSenha loginDto)
        {
            if (loginDto.LoginUuid == Guid.Empty)
            {
                throw new AtualizarLoginException("Login inválido. Erro ao atualizar.");
            }

            var login = await _context.LoginRepository.GetLogin(loginDto.LoginUuid);

            if (login == null || login.LoginId == 0)
            {
                throw new AtualizarLoginException("Login não encontrado. Erro ao atualizar.");
            }

            var loginBase = await _context.LoginRepository.GetByParameter(p => p.LoginUuid == loginDto.LoginUuid);
            loginBase.Senha = loginDto.Senha;
            _context.LoginRepository.Update(loginBase);
            await _context.Commit();
        }
    }
}
