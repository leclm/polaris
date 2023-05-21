using Microsoft.AspNetCore.Mvc;
using Polaris.Aluguel.Enums;
using Polaris.Aluguel.Services;
using Polaris.Aluguel.ViewModels;
using System.Xml.Linq;
using static Polaris.Aluguel.Exceptions.CustomExceptions;

namespace Polaris.Aluguel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlugueisController : UtilsController
    {
        private readonly IAlugueisService _service;

        public AlugueisController(IAlugueisService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este endpoint deve consultar os alugueis por cliente (cpf)
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os alugueis por um cliente
        /// </returns>
        /// GET: api/Alugueis/cliente
        [HttpGet("clientes")]
        public async Task<ActionResult> GetAlugueisPorCpf(string cpf)
        {
            try
            {
                return Ok(await _service.GetAlugueisPorCpf(cpf));
            }
            catch (AluguelNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve consultar os alugueis cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os alugueis cadastrados
        /// </returns>
        // GET: api/Alugueis
        [HttpGet]
        public async Task<ActionResult> GetAlugueis()
        {
            try
            {
                return Ok(await _service.GetAlugueis());
            }
            catch (AluguelNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um aluguel cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um aluguel cadastrado
        /// </returns>
        // GET: api/Alugueis/uuid
        [HttpGet("{uuid}", Name = "ObterAluguel")]
        public async Task<ActionResult> GetAluguel(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetAluguel(uuid));
            }
            catch (AluguelNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um aluguel
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/Alugueis
        [HttpPost]
        public async Task<ActionResult> PostAluguel(CadastroAluguelViewModel aluguelDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostAluguel(aluguelDto));
            }
            catch (AluguelNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarAluguelException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um aluguel via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Alugueis/uuid/status
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (AluguelNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar o estado de um aluguel via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Alugueis/uuid/status
        [HttpPut("alterar-disponibilidade/{uuid}/{estado}")]
        public async Task<ActionResult> AlterarDisponibilidade(Guid uuid, EstadoAluguel estado)
        {
            try
            {
                await _service.AlterarEstadoAluguel(uuid, estado);
                return Ok();
            }
            catch (AluguelNaoEncontradoException ex)
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
