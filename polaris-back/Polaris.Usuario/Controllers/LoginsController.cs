using Microsoft.AspNetCore.Mvc;
using Polaris.Usuario.Services;
using Polaris.Usuario.ViewModels;
using static Polaris.Usuario.Exceptions.CustomExceptions;

namespace Polaris.Usuario.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginsController : UtilsController
    {
        private readonly ILoginService _loginService;

        public LoginsController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        /// <summary>
        /// Este endpoint é utilizado para logar
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// {<br />
        /// "usuario": "usuario", <br />
        /// "senha": "senha" <br />
        /// }
        /// </remarks>
        /// <returns>
        /// Retorna 200 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/Logins/logar
        [HttpPost("logar")]
        public async Task<IActionResult> Logar(CadastroLoginViewModel loginDto)
        {
            try
            {
                return Ok(await _loginService.Logar(loginDto));
            }
            catch (LoginNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um usuario e/ou senha
        /// </summary>
        /// <remarks>
        ///  Exemplo: <br />
        /// {<br />
        /// "loginUuid": "14ed02ac-c05d-48c8-be3d-3cf84dc2b146", <br />
        /// "usuario": "usuario", <br />
        /// "senha": "senha" <br />
        /// }
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno         
        /// </returns>
        // PUT: api/Logins
        [HttpPut]
        public async Task<IActionResult> PutLogin(AtualizaLoginViewModel loginDto)
        {
            try
            {
                await _loginService.PutLogin(loginDto);
                return Ok();
            }
            catch (AtualizarLoginException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um login
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Logins/alterar-status/uuid/true 
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<IActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _loginService.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (LoginNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar a senha de um usuario
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Logins/alterar-senha
        [HttpPut("alterar-senha")]
        public async Task<IActionResult> AlterarSenha(AlteraSenha alteraSenha)
        {
            try
            {
                await _loginService.AlterarSenha(alteraSenha);
                return Ok();
            }
            catch (AtualizarLoginException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }
    }
}
