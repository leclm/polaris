﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.ViewModels;
using Polaris.Servico.Models;
using Polaris.Servico.Repository;
using Polaris.Servico.Services;
using Polaris.Servico.ViewModels;
using static Polaris.Servico.Exceptions.CustomExceptions;

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
        /// /// </summary>
        /// <returns>
        /// Retorna a lista com todos os serviços cadastrados por um terceirizado
        /// </returns>
        /// GET: api/Servicos/terceirizados
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
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // POST: api/Servicos
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
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        // PUT: api/Servicos/5
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
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
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
