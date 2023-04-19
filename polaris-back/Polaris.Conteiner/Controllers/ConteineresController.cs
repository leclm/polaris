using Microsoft.AspNetCore.Mvc;
using Polaris.Conteiner.Services;
using Polaris.Conteiner.ViewModels;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConteineresController : UtilsController
    {
        private readonly IConteineresService _service;

        public ConteineresController(IConteineresService service)
        {
            _service = service;
        }


        /// <summary>
        /// Este endpoint deve consultar os conteineres de uma categoria
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os conteineres de uma categoria
        /// </returns>
        /// GET: api/Conteineres/categoria
        [HttpGet("categorias")]
        public async Task<ActionResult> GettConteinerPorCategoria(string categoria)
        {
            try
            {
                return Ok(await _service.GetConteineresPorCategoria(categoria));
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve consultar os conteineres de um tipo
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os conteineres de um tipo
        /// </returns>
        /// GET: api/Conteineres/tipo
        [HttpGet("tipos")]
        public async Task<ActionResult> GetConteineresPorTipo(string tipo)
        {
            try
            {
                return Ok(await _service.GetConteineresPorTipo(tipo));
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve consultar os conteineres cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os conteineres cadastrados
        /// </returns>
        // GET: api/Conteineres
        [HttpGet]
        public async Task<ActionResult> GetConteineres()
        {
            try
            {
                return Ok(await _service.GetConteineres());
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar os conteineres ATIVOS
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os conteineres cadastrados
        /// </returns>
        // GET: api/Conteineres/conteineres-ativos
        [HttpGet("conteineres-ativos")]
        public async Task<ActionResult> GetConteineresAtivos()
        {
            try
            {
                return Ok(await _service.GetConteineresAtivos());
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar os conteineres ATIVOS e DISPONIVEIS
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os conteineres ativos e disponiveis cadastrados
        /// </returns>
        // GET: api/Conteineres/conteineres-ativos-disponiveis
        [HttpGet("conteineres-ativos-disponiveis")]
        public async Task<ActionResult> GetConteineresAtivosDisponiveis()
        {
            try
            {
                return Ok(await _service.GetConteineresAtivosDisponiveis());
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um conteiner cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um conteiner cadastrado
        /// </returns>
        // GET: api/Conteineres/uuid
        [HttpGet("{uuid}", Name = "ObterConteiner")]
        public async Task<ActionResult> GetConteiner(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetConteiner(uuid));
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um conteiner
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// { <br />
        /// "codigo": 100, <br />
        /// "fabricacao": "2023-04-13", <br />
        /// "fabricante": "Volvo", <br />
        ///  "material": "Metal", <br />
        ///  "cor": "Cinza", <br />
        ///  "categoria": "3fa85f64-5717-4562-b3fc-2c963f66afa6", <br />
        ///  "tipo": "3fa85f64-5717-4562-b3fc-2c963f66afa6" <br />
        /// } <br />
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/Conteineres
        [HttpPost]
        public async Task<ActionResult> PostConteiner(CadastroConteinerViewModel conteinerDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostConteiner(conteinerDto));
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarConteinerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um conteiner cadastrado
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// { <br />
        ///  "conteinerUuid": "3fa85f64-5717-4562-b3fc-2c963f66afa6",  <br />
        /// "fabricacao": "2023-04-13", <br />
        /// "fabricante": "Volvo", <br />
        ///  "material": "Metal", <br />
        ///  "cor": "Cinza", <br />
        ///  "categoria": "3fa85f64-5717-4562-b3fc-2c963f66afa6", <br />
        ///  "tipo": "3fa85f64-5717-4562-b3fc-2c963f66afa6" <br />
        /// } <br />
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno         
        /// </returns>
        // PUT: api/Conteineres
        [HttpPut]
        public async Task<IActionResult> PutConteiner(AtualizaConteinerViewModel conteinerDto)
        {
            try
            {
                await _service.PutConteiner(conteinerDto);
                return Ok();
            }
            catch (AtualizarConteinerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um conteiner via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Conteineres/uuid/status
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (ConteinerNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para disponivel ou indisponivel para locação um conteiner via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Conteineres/uuid/status
        [HttpPut("alterar-disponibilidade/{uuid}/{disponibilidade}")]
        public async Task<ActionResult> AlterarDisponibilidade(Guid uuid, bool disponibilidade)
        {
            try
            {
                await _service.AlterarDisponibilidade(uuid, disponibilidade);
                return Ok();
            }
            catch (ConteinerNaoEncontradoException ex)
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
