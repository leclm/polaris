using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Polaris.Usuario.Configs;
using Polaris.Usuario.Models;
using Polaris.Usuario.Repository;
using Polaris.Usuario.Utils;
using Polaris.Usuario.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Polaris.Usuario.Exceptions.CustomExceptions;

namespace Polaris.Usuario.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        private readonly TokenConfigs _tokenConfigs;

        public LoginService(IUnityOfWork context, IMapper mapper, IOptions<TokenConfigs> tokenConfigs)
        {
            _context = context;
            _mapper = mapper;
            _tokenConfigs = tokenConfigs.Value;
        }

        public async Task<RetornoLoginViewModel> Logar(CadastroLoginViewModel loginDto)
        {
            loginDto.Senha = GeraSenha(loginDto.Senha);
            var login = await _context.LoginRepository.GetByParameter(x => x.Usuario == loginDto.Usuario && x.Senha == loginDto.Senha);

            if (login == null || login.LoginId == 0)
            {
                throw new LoginNaoEncontradoException("Usuário/senha inválidos. Erro ao logar.");
            }

            var isGerente = await IsGerente(login.LoginId);

            return new RetornoLoginViewModel()
            {
                Usuario = loginDto.Usuario,
                Role = isGerente ? "gerente" : "cliente",
                LoginUuid = login.LoginUuid,
                Status = login.Status,
                Token = GeraToken(login)
            };
        }

        private string GeraToken(Login login)
        {
            //define declarações do usuário
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.UniqueName, login.Usuario),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            //gera uma chave com base em um algoritmo simetrico
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_tokenConfigs.Key));

            //gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //tempo de expiracão do token.
            var expiration = DateTime.UtcNow.AddHours(_tokenConfigs.ExpireHours);

            //classe que representa um token JWT e gera o token
            var token = new JwtSecurityToken(
              issuer: _tokenConfigs.Issuer,
              audience: _tokenConfigs.Audience,
              claims: claims,
              expires: expiration,
              signingCredentials: credenciais);

            //retorna o token como string
            return new JwtSecurityTokenHandler().WriteToken(token);
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

            var login = _mapper.Map<Login>(loginDto);
            login.Senha = GeraSenha(login.Senha);

            if (login is null)
            {
                throw new CadastrarLoginException("Usuário/senha inválidos. Erro ao cadastrar.");
            }

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
                login.Senha = GeraSenha(loginDto.Senha);


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
            loginBase.Senha = GeraSenha(loginDto.Senha);
            _context.LoginRepository.Update(loginBase);
            await _context.Commit();
        }

        private static string GeraSenha(string senha)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: senha,
                    salt: BitConverter.GetBytes(2406),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                ));
        }
    }
}
