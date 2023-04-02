using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polaris.Endereco.DTOs;
using Polaris.Endereco.Models;
using Polaris.Endereco.Repository;
using System.Xml.Linq;

namespace Polaris.Endereco.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public EnderecosController(IUnityOfWork contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }

        //// GET: api/CategoriasProdutos
        //[HttpGet("produtos")]
        //public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        //{
        //    var categorias = await _context.CategoriaRepository.GetCategoriasProdutos();
        //    var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
        //    return categoriasDto;

        //}

        // GET: api/Enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetEnderecos()
        {
            var enderecos = await _context.EnderecoRepository.Get().ToListAsync();
            if (enderecos is null)
            {
                return NotFound("Não há endereços cadastrados.");
            }
            var enderecosDto = _mapper.Map<List<EnderecoDTO>>(enderecos);
            return enderecosDto;
        }

        // GET: api/Enderecos/5
        [HttpGet("{id:int:min(1)}", Name = "ObterEndereco")]
        public async Task<ActionResult<EnderecoDTO>> GetEndereco(int id)
        {
            var endereco = await _context.EnderecoRepository.GetById(p => p.EnderecoId == id);

            if (endereco is null)
            {
                return NotFound("Endereço não encontrado.");
            }
            var enderecoDto = _mapper.Map<EnderecoDTO>(endereco);
            return enderecoDto;
        }


        // POST: api/Enderecos
        [HttpPost]
        public async Task<ActionResult<EnderecoDTO>> PostEndereco(EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Models.Endereco>(enderecoDto);

            if (endereco is null) return BadRequest("Erro ao cadastrar um endereço.");

            _context.EnderecoRepository.Add(endereco);
            await _context.Commit();

            var enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);

            return new CreatedAtRouteResult("ObterEndereco", new { id = endereco.EnderecoId }, enderecoDTO);
        }

        // PUT: api/Enderecos/5
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> PutEndereco(EnderecoDTO enderecoDto)
        {
            if (enderecoDto.EnderecoId != enderecoDto.EnderecoId)
            {
                return BadRequest("Erro ao atualizar o endereço.");
            }

            var endereco = _mapper.Map<Models.Endereco>(enderecoDto);

            _context.EnderecoRepository.Add(endereco);
            await _context.Commit();
            return Ok();
        }

        // DELETE: api/Enderecos/5 FAZER COM DESATIVAR
        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<EnderecoDTO>> DeleteEndereco(int id)
        {
            var endereco = await _context.EnderecoRepository.GetById(p => p.EnderecoId == id);

            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            _context.EnderecoRepository.Delete(endereco);
            await _context.Commit();

            var enderecoDto = _mapper.Map<EnderecoDTO>(endereco);
            return enderecoDto;
        }
    }
}
