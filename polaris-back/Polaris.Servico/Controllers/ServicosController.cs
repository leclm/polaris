using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.ViewModels;
using Polaris.Servico.Models;
using Polaris.Servico.Repository;
using Polaris.Servico.Services;
using Polaris.Servico.ViewModels;
using static Polaris.Servico.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Cors;

namespace Polaris.Servico.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicosController : UtilsController
    {
        private readonly IServicosService _service;

        public ServicosController(IServicosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este endpoint deve consultar os serviços oferecidos por um terceirizado
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo:<br />
        ///
        ///    GET: api/Servicos/terceirizados<br /> <br />
        ///     {<br />
        ///        "cnpj": "32.738.811/0001-80"<br />
        ///     }<br />
        ///
        /// </remarks>
        /// <returns>
        /// Retorna a lista com todos os serviços cadastrados por um terceirizado
        /// </returns>
        [HttpGet("terceirizados")]
        public async Task<ActionResult> GetServicosPorTerceirizado(string cnpj)
        {
            try
            {
                return Ok(_service.GetServicosPorTerceirizado(cnpj));
            }
            catch (ServicoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }


        /// <summary>
        /// Este endpoint deve consultar os serviços cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os serviços cadastrados
        /// </returns>
        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult> GetServicos()
        {
            try
            {
                return Ok(await _service.GetServicos());
            }
            catch (ServicoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um serviço cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um serviço cadastrado
        /// </returns>
        // GET: api/Servicos/5
        [HttpGet("{uuid}", Name = "ObterServico")]
        public async Task<ActionResult> GetServico(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetServico(uuid));
            }
            catch (ServicoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um serviço
        /// </summary>
        /// <remarks>
        /// Exemplo:<br />
        ///     {<br />
        ///        "nome": "limpeza" <br />
        ///     }<br />
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        //GET: api/Servicos
        [HttpPost]
        public async Task<ActionResult> PostServico(CadastroServicoViewModel servicoDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostServico(servicoDto));
            }
            catch (ServicoNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarServicoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um serviço cadastrado
        /// </summary>
        /// <remarks>
        /// Exemplo:<br />
        ///     {<br />
        ///        "servicoUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722" <br />
        ///        "nome": "limpeza" <br />
        ///     }<br />
        ///
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno 
        /// </returns>
        //PUT: api/Servicos
        [HttpPut]
        public async Task<IActionResult> PutServico(AtualizaServicoViewModel servicoDto)
        {
            try
            {
                await _service.PutServico(servicoDto);
                return Ok();
            }
            catch (AtualizarServicoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um serviço via Guid
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
            catch (ServicoNaoEncontradoException ex)
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
