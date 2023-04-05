using Microsoft.AspNetCore.Mvc;
using Polaris.Servico.Services;
using Polaris.Servico.ViewModels;
using static Polaris.Servico.Exceptions.CustomExceptions;

namespace Polaris.Servico.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TerceirizadosController : UtilsController
    {
        private readonly ITerceirizadosService _service;

        public TerceirizadosController(ITerceirizadosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este endpoint deve consultar os terceirizados que prestam o serviço buscado
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os terceirizados que prestam um determinado serviço
        /// </returns>
        /// GET: api/Terceirizados/servicos
        [HttpGet("servicos")]
        public async Task<ActionResult> GetTerceirizadosPorServico(string servico)
        {
            try
            {
                return Ok(_service.GetTerceirizadosPorServico(servico));
            }
            catch (TerceirizadoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve consultar os terceirizados cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os terceirizados cadastrados
        /// </returns>
        // GET: api/Terceirizados
        [HttpGet]
        public async Task<ActionResult> GetTerceirizadoss()
        {
            try
            {
                return Ok(await _service.GetTerceirizados());
            }
            catch (TerceirizadoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um terceirizado cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um terceirizado cadastrado
        /// </returns>
        // GET: api/Terceirizados/5
        [HttpGet("{uuid}", Name = "ObterTerceirizado")]
        public async Task<ActionResult> GetTerceirizado(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetTerceirizado(uuid));
            }
            catch (TerceirizadoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um terceirizado
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // POST: api/Terceirizados
        [HttpPost]
        public async Task<ActionResult> PostTerceirizadoo(CadastroTerceirizadoViewModel terceirizadoDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostTerceirizado(terceirizadoDto));
            }
            catch (TerceirizadoNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarTerceirizadoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um terceirizado cadastrado
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // PUT: api/Terceirizados/5
        [HttpPut]
        public async Task<IActionResult> PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadooDto)
        {
            try
            {
                await _service.PutTerceirizado(terceirizadooDto);
                return Ok();
            }
            catch (AtualizarTerceirizadoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um terceirizo via Guid
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // ALTERAR STATUS: api/Terceirizados/5
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (TerceirizadoNaoEncontradoException ex)
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
