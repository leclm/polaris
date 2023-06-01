using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polaris.Conteiner.Enums;
using Polaris.Conteiner.Models;
using Polaris.Conteiner.Services;
using Polaris.Conteiner.ViewModels;
using System;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class PrestacoesServicosController : UtilsController
    {

        private readonly IPrestacoesServicosService _service;

        public PrestacoesServicosController(IPrestacoesServicosService service)
        {
            _service = service;
        }


        ///// <summary>
        ///// Este endpoint deve consultar as prestações de serviços realizadas por um terceirizado
        ///// </summary>
        ///// <returns>
        ///// Retorna a lista com todas as prestações de serviços realizadas por um terceirizado
        ///// </returns>
        ///// GET: api/PrestacoesServico/terceirizado
        //[HttpGet("Terceirizado/{terceirizado}")]
        //public async Task<ActionResult> GetPrestacoesServicosPorTerceirizado(string terceirizado)
        //{
        //    try
        //    {
        //        //return Ok(await _service.GetTerceirizadosPorServico(servico));
        //        return Ok();
        //    }
        //    catch (PrestacaoServicoNaoEncontradaException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return ReturnError();
        //    }
        //}

        /// <summary>
        /// Este endpoint deve consultar as prestações de serviços realizadas em um conteiner
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as prestações de serviços realizadas em um conteiner
        /// </returns>
        /// GET: api/PrestacoesServico/conteiner
        [HttpGet("Conteiner/{uuidConteiner}")]
        public async Task<ActionResult> GetPrestacoesServicosPorConteiner(Guid uuidConteiner)
        {
            try
            {
                return Ok(await _service.GetPrestacoesServicosPorConteiner(uuidConteiner));
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
        /// Este endpoint deve consultar as prestações de serviço cadastradas
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as prestações de serviço 
        /// </returns>
        // GET: api/PrestacoesServico
        [HttpGet]
        public async Task<ActionResult> GetPrestacaoDeServicos()
        {
            try
            {
                return Ok(await _service.GetPrestacaoDeServicos());
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
        ///   "dataProcedimento":  "2023-04-25T01:25:14.191Z",, <br />
        ///   "comentario": "Ficou perfeito!", <br />
        ///  "conteiner": "0eaeb76b-4b80-4aea-a953-391ac183f7f3",   <br />
        ///    "terceriizado": "5e80c929-4bb2-4375-8082-c6ca3172a278", <br />
        ///    "servico": "146325cf-0c25-4396-8c99-92f62a654cad" <br />
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
                return StatusCode(StatusCodes.Status201Created, await _service.PostPrestacaoDeServico(prestacaoServicoDto));
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

        ///// <summary>
        ///// Este endpoint deve atualizar uma prestação de serviço
        ///// </summary>
        ///// <remarks>
        ///// Exemplo: <br />
        ///// { <br />
        /////   "terceirizadoUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722, <br />
        /////   "cnpj":"32.738.811/0001-80",<br />
        /////   "empresa": "Empresa Exemplo", <br />
        /////   "email": "exemplo@email.com", <br />
        /////   "telefone": "(XX)XXXXX-XXXX",   <br />
        /////   "endereco": { <br />
        /////   "enderecooUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722,<br />
        /////   "cep": "80220000", <br />
        /////   "cidade": "Curitiba", <br />
        /////   "estado": "Paraná",  <br />
        /////   "logradouro": "Rua Exemplo",  <br />
        /////   "complemento": "opcional",  <br />
        /////   "numero": 100  <br />
        /////   },  <br />
        /////   "listaServicos": [  <br />
        /////   "3fa85f64-5717-4562-b3fc-2c963f66afa6"  <br />
        /////   ]<br />}
        ///// </remarks>
        ///// <returns>
        ///// Retorna 201 caso sucesso
        ///// Retorna 400 caso erro, retorna a mensagem especificando
        ///// Retorna 500 caso erro interno         
        ///// </returns>
        //// PUT: api/PrestacoesServico
        //[HttpPut]
        //public async Task<IActionResult> PutPrestacaoServico(AtualizaPrestacaoDeServicoViewModel prestacaoServicoDto)
        //{
        //    try
        //    {
        //        //await _service.PutPrestacaoServico(prestacaoServicoDto);
        //        return Ok();
        //    }
        //    catch (AtualizarPrestacaoServicoException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnError();
        //    }
        //}

        /// <summary>
        /// Este endpoint deve alterar o estado da prestação de serviço via Guid
        /// </summary>
        /// <returns>
        /// Retorna 200 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // PUT: api/PrestacoesServico/uuid/status
        // PUT: api/PrestacoesServico/EstadoPrestacaoDeServico
        [HttpPut("alterar-estado")]
        public async Task<IActionResult> PutEstadoPrestacaoDeServico(AlteraEstadoPrestacaoServico estado)
        {
            try
            {
                await _service.PutEstadoPrestacaoDeServico(estado);
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

        ///// <summary>
        ///// Este endpoint deve alterar o status de serviço de uma prestação de serviço via Guid
        ///// </summary>
        ///// <returns>
        ///// Retorna 201 caso sucesso
        ///// Retorna 404 caso uuid não encontrado
        ///// Retorna 500 caso erro interno         
        ///// </returns>
        //// ALTERAR STATUS: api/PrestacoesServico/uuid/status
        //[HttpPut("alterar-status/{uuid}/{status}")]
        //public async Task<ActionResult> AlterarStatus(Guid uuid, EstadoConteiner status)
        //{
        //    try
        //    {
        //        //await _service.AlterarStatus(uuid, status);
        //        return Ok();
        //    }
        //    catch (PrestacaoServicoNaoEncontradaException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return ReturnError();
        //    }
        //}
    }
}
