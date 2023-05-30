using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polaris.Usuario.Services;
using Polaris.Usuario.ViewModels;
using static Polaris.Usuario.Exceptions.CustomExceptions;

namespace Polaris.Usuario.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class GerentesController : UtilsController
    {
        private readonly IGerenteService _service;

        public GerentesController(IGerenteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este endpoint deve consultar os gerentes cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os gerentes cadastrados
        /// </returns>
        // GET: api/Gerentes
        [HttpGet]
        public async Task<ActionResult> GetGerentes()
        {
            try
            {
                return Ok(await _service.GetGerentes());
            }
            catch (GerenteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar os gerentes ATIVOS
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os gerentes cadastrados
        /// </returns>
        // GET: api/Gerentes/gerentes-ativos
        [HttpGet("gerentes-ativos")]
        public async Task<ActionResult> GetGerentesAtivos()
        {
            try
            {
                return Ok(await _service.GetGerentesAtivos());
            }
            catch (GerenteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um gerente cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um gerente cadastrado
        /// </returns>
        // GET: api/Gerentes/uuid
        [HttpGet("{uuid}", Name = "ObterGerente")]
        public async Task<ActionResult> GetGerente(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetGerente(uuid));
            }
            catch (GerenteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um gerente
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/Gerentes
        [HttpPost]
        public async Task<ActionResult> PostGerente(CadastroGerenteViewModel gerenteDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostGerente(gerenteDto));
            }
            catch (GerenteNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarGerenteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um gerente cadastrado
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno         
        /// </returns>
        // PUT: api/Gerentes
        [HttpPut]
        public async Task<IActionResult> PutGerente(AtualizaGerenteViewModel gerenteDto)
        {
            try
            {
                await _service.PutGerente(gerenteDto);
                return Ok();
            }
            catch (AtualizarGerenteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um gerente via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Gerentes/uuid/status
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (GerenteNaoEncontradoException ex)
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
