using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Polaris.CategoriaConteiner.Services;
using Polaris.CategoriaConteiner.ViewModels;
using static Polaris.CategoriaConteiner.Exceptions.CustomException;

namespace Polaris.CategoriaConteiner.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasConteinerController : UtilsController
    {
        private readonly ICategoriasConteinerService _service;

        public CategoriasConteinerController(ICategoriasConteinerService service)
        {
            _service = service;
        } 
        
        
        /// <summary>
        /// Este endpoint deve consultar as categorias cadastradas
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as categorias cadastradas
        /// </returns>
        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult> GetCategorias()
        {
            try
            {
                return Ok(await _service.GetCategorias());
            }
            catch (CategoriaConteinerNaoEncontradaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar uma categoria cadastrada via Guid
        /// </summary>
        /// <returns>
        /// Retorna uma categoria cadastrada
        /// </returns>
        // GET: api/Categorias/uuid
        [HttpGet("{uuid}", Name = "ObterCategoria")]
        public async Task<ActionResult> GetCategoria(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetCategoria(uuid));
            }
            catch (CategoriaConteinerNaoEncontradaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar uma categoria
        /// </summary>
        /// <remarks>
        /// Exemplo:<br />
        ///     {<br />
        ///        "nome": "loja" <br />
        ///     }<br />
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        //GET: api/Categorias
        [HttpPost]
        public async Task<ActionResult> PostCategoria(CadastroCategoriaConteinerViewModel categoriaDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostCategoria(categoriaDto));
            }
            catch (CategoriaConteinerNaoEncontradaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastraCategoriaConteinerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar uma categoria cadastrada
        /// </summary>
        /// <remarks>
        /// Exemplo:<br />
        ///     {<br />
        ///        "categoriaUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722" <br />
        ///        "nome": "loja" <br />
        ///     }<br />
        ///
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno 
        /// </returns>
        //PUT: api/Categorias
        [HttpPut]
        public async Task<IActionResult> PutCagoria(AtualizarCategoriaConteinerViewModel categoriaDto)
        {
            try
            {
                await _service.PutCategoria(categoriaDto);
                return Ok();
            }
            catch (AtualizarCategoriaConteinerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de uma categoria via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno 
        /// </returns>
        // ALTERAR STATUS: api/Servicos/5
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (CategoriaConteinerNaoEncontradaException ex)
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
