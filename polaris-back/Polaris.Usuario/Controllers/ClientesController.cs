using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polaris.Usuario.Services;
using Polaris.Usuario.ViewModels;
using static Polaris.Usuario.Exceptions.CustomExceptions;

namespace Polaris.Usuario.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : UtilsController 
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }


        /// <summary>
        /// Este endpoint deve consultar os clientes cadastrados
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os clientes cadastrados
        /// </returns>
        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult> GetClientes()
        {
            try
            {
                return Ok(await _service.GetClientes(Request!.Headers!.Authorization!));
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar os clientes ATIVOS
        /// </summary>
        /// <returns>
        /// Retorna a lista com todos os clientes cadastrados
        /// </returns>
        // GET: api/Clientes/clientes-ativos
        [HttpGet("clientes-ativos")]
        public async Task<ActionResult> GetClientesAtivos()
        {
            try
            {
                return Ok(await _service.GetClientesAtivos(Request!.Headers!.Authorization!));
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }

        }

        /// <summary>
        /// Este endpoint deve consultar um cliente cadastrado via Guid
        /// </summary>
        /// <returns>
        /// Retorna um cliente cadastrado
        /// </returns>
        // GET: api/Clientes/uuid
        [HttpGet("{uuid}", Name = "ObterCliente")]
        public async Task<ActionResult> GetCliente(Guid uuid)
        {
            try
            {
                return Ok(await _service.GetCliente(uuid, Request!.Headers!.Authorization!));
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve cadastrar um cliente
        /// </summary>
        /// <remarks>
        /// Exemplo: <br />
        /// {<br />
        ///"cpf": "555.843.410-45",<br />
        ///"nome": "Maria",<br />
        ///"sobrenome": "Polaris",<br />
        ///"dataNascimento": "2023-05-08",<br />
        /// "email": "email@email.com",<br />
        /// "telefone": "41999999999",<br />
        /// "endereco": {<br />
        /// "cep": "85660000",<br />
        /// "cidade": "Curitiba",<br />
        /// "estado": "PR",<br />
        /// "logradouro": "Rua do Teste",<br />
        /// "complemento": "Apt 1",<br />
        /// "numero": 10<br />
        ///}<br />
        /// }
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult> PostCliente(CadastroClienteViewModel clienteDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.PostCliente(clienteDto, Request!.Headers!.Authorization!));
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CadastrarClienteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar um cliente cadastrado
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro, retorna a mensagem especificando
        /// Retorna 500 caso erro interno         
        /// </returns>
        // PUT: api/Clientes
        [HttpPut]
        public async Task<IActionResult> PutCliente(AtualizaClienteViewModel clienteDto)
        {
            try
            {
                await _service.PutCliente(clienteDto, Request!.Headers!.Authorization!);
                return Ok();
            }
            catch (AtualizarClienteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve alterar para ativado ou desativado o status de um cliente via Guid
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // ALTERAR STATUS: api/Clientes/uuid/status
        [HttpPut("alterar-status/{uuid}/{status}")]
        public async Task<ActionResult> AlterarStatus(Guid uuid, bool status)
        {
            try
            {
                await _service.AlterarStatus(uuid, status);
                return Ok();
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        /// <summary>
        /// Este endpoint deve buscar qual cliente está vinculado com o aluguel buscado
        /// </summary>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 404 caso uuid não encontrado
        /// Retorna 500 caso erro interno         
        /// </returns>
        // AGET: api/Enderecos/buscar-cliente-aluguel/uuid
        [HttpGet("buscar-cliente-aluguel/{uuidAluguel}")]
        public async Task<IActionResult> BuscarVinculoClienteAluguel(Guid uuidAluguel)
        {
            try
            {
                return Ok(await _service.BuscarVinculoClienteAluguel(uuidAluguel));
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }
    }
}
