using Microsoft.AspNetCore.Mvc;
using Polaris.Conteiner.Enums;
using Polaris.Conteiner.Models;
using Polaris.Conteiner.Services;
using Polaris.Conteiner.ViewModels;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrestacoesServicosController : UtilsController
    {

        private readonly IPrestacoesServicosService _service;

        public PrestacoesServicosController(IPrestacoesServicosService service)
        {
            _service = service;
        }


        /// <summary>
        /// Este endpoint deve consultar as prestações de serviços realizadas por um terceirizado
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as prestações de serviços realizadas por um terceirizado
        /// </returns>
        /// GET: api/PrestacoesServico/terceirizado
        [HttpGet("PrestacoesServico")]
        public async Task<ActionResult> GetPrestacoesServicosPorTerceirizado(string terceirizado)
        {
            try
            {
                //return Ok(await _service.GetTerceirizadosPorServico(servico));
                return Ok();
            }
            catch (PrestacaoServicoNaoEncontradaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve consultar as prestações de serviço cadastradas
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as prestações de serviço 
        /// </returns>
        // GET: api/PrestacoesServico
        [HttpGet]
        public async Task<ActionResult> GetPrestacoesServicos()
        {
            try
            {
                //return Ok(await _service.GetTerceirizados());
                return Ok();
            }
            catch (PrestacaoServicoNaoEncontradaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar uma prestação de serviço cadastrada via Guid
        /// </summary>
        /// <returns>
        /// Retorna uma prestação de serviço
        /// </returns>
        // GET: api/PrestacoesServico/uuid
        [HttpGet("{uuid}", Name = "ObterPrestacaoServico")]
        public async Task<ActionResult> GetPrestacaoServico(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetPrestacaoDeServico(uuid));
            }
            catch (PrestacaoServicoNaoEncontradaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar uma prestração de serviço
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// { <br />
        ///   "cnpj":"32.738.811/0001-80",<br />
        ///   "empresa": "Empresa Exemplo", <br />
        ///   "email": "exemplo@email.com", <br />
        ///   "telefone": "(XX)XXXXX-XXXX",   <br />
        ///   "endereco": { <br />
        ///   "cep": "80 220 000", <br />
        ///   "cidade": "Curitiba", <br />
        ///   "estado": "Paraná",  <br />
        ///   "logradouro": "Rua Exemplo",  <br />
        ///   "complemento": "opcional",  <br />
        ///   "numero": 100  <br />
        ///   },  <br />
        ///   "listaServicos": [  <br />
        ///   "3fa85f64-5717-4562-b3fc-2c963f66afa6"  <br />
        ///   ]<br />}
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/PrestacoesServico
        [HttpPost]
        public async Task<ActionResult> PostPrestacoesServico(CadastroPrestacaoDeServicoViewModel prestacaoServicoDto)
        {
            try
            {
                //return StatusCode(StatusCodes.Status201Created, await _service.PostTerceirizado(prestacaoServicoDto));
                return Ok();
            }
            catch (PrestacaoServicoNaoEncontradaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarPrestacaoServicoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar uma prestação de serviço
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// { <br />
        ///   "terceirizadoUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722, <br />
        ///   "cnpj":"32.738.811/0001-80",<br />
        ///   "empresa": "Empresa Exemplo", <br />
        ///   "email": "exemplo@email.com", <br />
        ///   "telefone": "(XX)XXXXX-XXXX",   <br />
        ///   "endereco": { <br />
        ///   "enderecooUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722,<br />
        ///   "cep": "80220000", <br />
        ///   "cidade": "Curitiba", <br />
        ///   "estado": "Paraná",  <br />
        ///   "logradouro": "Rua Exemplo",  <br />
        ///   "complemento": "opcional",  <br />
        ///   "numero": 100  <br />
        ///   },  <br />
        ///   "listaServicos": [  <br />
        ///   "3fa85f64-5717-4562-b3fc-2c963f66afa6"  <br />
        ///   ]<br />}
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno         
        /// </returns>
        // PUT: api/PrestacoesServico
        [HttpPut]
        public async Task<IActionResult> PutPrestacaoServico(AtualizaPrestacaoDeServicoViewModel prestacaoServicoDto)
        {
            try
            {
                //await _service.PutTerceirizado(prestacaoServicoDto);
                return Ok();
            }
            catch (AtualizarPrestacaoServicoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar o status de serviço de uma prestação de serviço via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/PrestacoesServico/uuid/status
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, EstadoConteiner status)
        {
            try
            {
                //await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (PrestacaoServicoNaoEncontradaException ex)
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
