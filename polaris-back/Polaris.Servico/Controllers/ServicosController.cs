using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.DTOs;
using Polaris.Servico.Models;
using Polaris.Servico.Repository;

namespace Polaris.Servico.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public ServicosController(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ServicosTerceirizados
        [HttpGet("terceirizados")]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> GetServicosTerceirizados()
        {
            var servicos = await _context.ServicoRepository.GetServicosTerceirizados();
            var servicosDto = _mapper.Map<List<ServicoDTO>>(servicos);
            return servicosDto;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> GetServicos()
        {
            var servicos = await _context.ServicoRepository.Get().ToListAsync();
            if (servicos is null)
            {
                return NotFound("Não há serviços cadastrados.");
            }
            var servicosDto = _mapper.Map<List<ServicoDTO>>(servicos);
            return servicosDto;
        }

        // GET: api/Servicos/5
        [HttpGet("{id:int:min(1)}", Name = "ObterServico")]
        public async Task<ActionResult<ServicoDTO>> GetServico(int id)
        {
            var servico = await _context.ServicoRepository.GetById(p => p.ServicoId == id);

            if (servico is null)
            {
                return NotFound("Servico não encontrado.");
            }
            var servicoDto = _mapper.Map<ServicoDTO>(servico);
            return servicoDto;
        }

        // POST: api/Servicos
        [HttpPost]
        public async Task<ActionResult<ServicoDTO>> PostServico(ServicoDTO servicoDto)
        {
            try
            {
                var servico = _mapper.Map<Models.Servico>(servicoDto); if (servicoDto is null) return BadRequest("Erro ao cadastrar um serviço.");

                servico.Nome = servico.Nome.ToUpper();
                _context.ServicoRepository.Add(servico);
                await _context.Commit();

                var servicoDTO = _mapper.Map<ServicoDTO>(servico);

                return new CreatedAtRouteResult("ObterServico", new { id = servico.ServicoId }, servicoDTO);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Serviço já cadastrado.");
            }
        }

        // PUT: api/Servicos/5
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> PutServico(int id, ServicoDTO servicoDto)
        {
            try
            {
                if (id != servicoDto.ServicoId)
                {
                    return BadRequest("Erro ao atualizar um serviço.");
                }

                var servico = _mapper.Map<Models.Servico>(servicoDto);

                servico.Nome = servico.Nome.ToUpper();
                _context.ServicoRepository.Update(servico);
                await _context.Commit();
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Serviço já cadastrado.");
            }
        }

        // ALTERAR STATUS: api/Servicos/5
        [HttpPut("alterar-status/{id:int:min(1)}")]
        public async Task<ActionResult<ServicoDTO>> AlterarStatus(int id, bool status)
        {
            var servico = await _context.ServicoRepository.GetById(p => p.ServicoId == id);
            if (servico == null)
            {
                return NotFound("Serviço não encontrado.");
            }

            servico.Status = status;

            _context.ServicoRepository.Update(servico);
            await _context.Commit(); 

            var servicoDto = _mapper.Map<ServicoDTO>(servico);

            return servicoDto;
        }
    }
}
