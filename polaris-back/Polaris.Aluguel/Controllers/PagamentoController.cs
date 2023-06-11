using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polaris.Aluguel.Services;
using Polaris.Aluguel.ViewModels;
using static Polaris.Aluguel.Exceptions.CustomExceptions;

namespace Polaris.Aluguel.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class PagamentoController : UtilsController
    {
        private readonly IPagamentoService _service;

        public PagamentoController(IPagamentoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este endpoint deve pagar um aluguel via PayPal
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Retorna 201 caso sucesso
        /// Retorna 400 caso erro em algum campo com a mensagem
        /// Retorna 500 caso erro interno 
        /// </returns>
        // POST: api/Alugueis
        [HttpPost]
        public async Task<ActionResult> PostPagamento(PagarAluguelViewModel pagarAluguelDto)
        {
            try
            {
                await _service.PagarAluguelPayPal(pagarAluguelDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (PagamentoPayPalException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return ReturnError();
            }
        }
    }
}
