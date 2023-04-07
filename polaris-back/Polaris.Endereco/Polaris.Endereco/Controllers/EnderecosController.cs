﻿using Microsoft.AspNetCore.Mvc;
using Polaris.Endereco.DTOs;
using Polaris.Endereco.Services;
using static Polaris.Endereco.Exceptions.CustomExceptions;

namespace Polaris.Endereco.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecosController : UtilsController
    {
        private readonly IEnderecosService _service;
        

        public EnderecosController(IEnderecosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este endpoint deve consultar os endereços cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os endereços cadastrados
        /// </returns>
        // GET: api/Enderecos
        [HttpGet]
        public async Task<IActionResult> GetEnderecos()
        {
            try
            {
                return Ok(await _service.GetEnderecos());
            }
            catch (EnderecoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve consultar um endereço cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um endereço cadastrado
        /// </returns>
        // GET: api/Enderecos/5
        [HttpGet("{uuid}", Name = "ObterEndereco")]
        public async Task<IActionResult> GetEndereco(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetEndereco(uuid));
            }
            catch (EnderecoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um endereço
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// {<br />
        /// "cep": "80222666", <br />
        /// "cidade": "Curitiba", <br />
        /// "estado": "Paraná", <br />
        /// "logradouro": "Rua Exemplo",<br />  
        /// "complemento": "opcional",<br />
        /// "numero": 100<br />
        /// }
        /// </remarks>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // POST: api/Enderecos
        [HttpPost]
            public async Task<IActionResult> PostEndereco(CadastroEnderecoViewModel enderecoDto)
            {
                try
                {
                    return StatusCode(StatusCodes.Status201Created, await _service.PostEndereco(enderecoDto));
                }
                catch (EnderecoNaoEncontradoException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    return ReturnError();
                }
            }

        /// <summary>
        /// Este endpoint deve atualizar um endereço cadastrado
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// {<br />
        /// "EnderecoUuid": "7db3f5dc-b90c-4d7d-b179-1d2341a96722", <br />
        /// "cep": "80222666", <br />
        /// "cidade": "Curitiba", <br />
        /// "estado": "Paraná", <br />
        /// "logradouro": "Rua Exemplo", <br />
        /// "complemento": "opcional",<br />
        /// "numero": 100<br />
        /// }
        /// </remarks>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // PUT: api/Enderecos/5
        [HttpPut]
        public async Task<IActionResult> PutEndereco(AtualizaEnderecoViewModel enderecoDto)
        {
            try
            {
                await _service.PutEndereco(enderecoDto);
                return Ok();
            }
            catch (AtualizarEnderecoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um endereço via Guid
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // ALTERAR STATUS: api/Enderecos/altera-status/5/true 
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<IActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (EnderecoNaoEncontradoException ex)
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