using Microsoft.AspNetCore.Mvc;
using Polaris.TipoConteiner.Services;
using Polaris.TipoConteiner.ViewModels;
using static Polaris.TipoConteiner.Exceptions.CustomExceptions;

namespace Polaris.TipoConteiner.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TiposConteineresController : UtilsController
    {
        private readonly ITiposConteineresService _service;

        public TiposConteineresController(ITiposConteineresService service)
        {
            _service = service;
        }  
        
        /// <summary>
        /// Este endpoint deve consultar os tipos de conteineres cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os tipos cadastrados
        /// </returns>
        // GET: api/Tipos
        [HttpGet]
        public async Task<ActionResult> GetTipos()
        {
            try
            {
                return Ok(await _service.GetTipos());
            }
            catch (TipoConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um tipo de conteiner cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um tipo cadastrado
        /// </returns>
        // GET: api/GetTipos/uuid
        [HttpGet("{uuid}", Name = "ObterTipo")]
        public async Task<ActionResult> GetTipo(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetTipo(uuid));
            }
            catch (TipoConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um tipo de conteiner
        /// </summary>
        /// <remarks>
        /// Exemplo:<br />
        ///     {<br />
        ///        "nome": "pequeno", <br />
        ///        "largura": 2.20 <br />
        ///        "comprimento": 2.20 <br />
        ///        "volume": 2.20 <br />
        ///        "pesoMaximo": 2.20 <br />
        ///        "altura": 2.20 <br />
        ///        "valorDiaria": 200.00 <br />
        ///        "valorMensal": 2200.00 <br />
        ///     }<br />
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        //GET: api/Tipos
        [HttpPost]
        public async Task<ActionResult> PostServico(CadastroTipoConteinerViewModel tipoDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostTipo(tipoDto));
            }
            catch (TipoConteinerNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarTipoConteinerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um tipo de conteiner cadastrado
        /// </summary>
        /// <remarks>
        /// Exemplo:<br />
        ///      {<br />
        ///        "tipoConteinerUuid":  "7db3f5dc-b90c-4d7d-b179-1d2341a96722", <br />
        ///        "nome": "pequeno", <br />
        ///        "largura": 2.20 <br />
        ///        "comprimento": 2.20 <br />
        ///        "volume": 2.20 <br />
        ///        "pesoMaximo": 2.20 <br />
        ///        "altura": 2.20 <br />
        ///        "valorDiaria": 200.00 <br />
        ///        "valorMensal": 2200.00 <br />
        ///     }<br />
        ///
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno 
        /// </returns>
        //PUT: api/Tipos
        [HttpPut]
        public async Task<IActionResult> PutTipo(AtualizaTipoConteinerViewModel tipoDto)
        {
            try
            {
                await _service.PutTipo(tipoDto);
                return Ok();
            }
            catch (AtualizarTipoConteinerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um tipo de conteiner via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno 
        /// </returns>
        // ALTERAR STATUS: api/Tipos/uui/status
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (TipoConteinerNaoEncontradoException ex)
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
