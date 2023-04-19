using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Repository;
using Polaris.Conteiner.Utils;
using Polaris.Conteiner.ViewModels;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Services
{
    public class TiposConteineresService : ITiposConteineresService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public TiposConteineresService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RetornoTipoConteinerViewModel>> GetTipos()
        {
            var tipos = await _context.TipoConteinerRepository.Get().ToListAsync();
            if (tipos is null)
            {
                throw new TipoConteinerNaoEncontradoException("Não há tipos de conteiner cadastrados.");
            }
            var tiposDto = _mapper.Map<List<RetornoTipoConteinerViewModel>>(tipos);
            return tiposDto;
        }

        public async Task<RetornoTipoConteinerViewModel> GetTipo(Guid uuid)
        {
            var tipo = await _context.TipoConteinerRepository.GetByParameter(p => p.TipoConteinerUuid == uuid);

            if (tipo is null)
            {
                throw new TipoConteinerNaoEncontradoException("Não há tipos de conteiner cadastrados.");
            }
            var tipoDto = _mapper.Map<RetornoTipoConteinerViewModel>(tipo);
            return tipoDto;
        }
        public async Task<IEnumerable<RetornoTipoConteinerViewModel>> GetTiposAtivos()
        {
            var tipos = _context.TipoConteinerRepository.GetAllByParameter(x => x.Status == true);
            if (!tipos.Any())
            {
                throw new TipoConteinerNaoEncontradoException("Não há tipos ativas.");
            }
            return _mapper.Map<List<RetornoTipoConteinerViewModel>>(tipos);
        }

        public async Task<Guid> PostTipo(CadastroTipoConteinerViewModel tipoDto)
        {
            if (await _context.TipoConteinerRepository.GetByParameter(x => x.Nome == tipoDto.Nome) is not null)
            {
                throw new CadastrarTipoConteinerException("Tipo de conteiner já existe. Erro ao cadastrar um tipo.");
            };

            var tipo = _mapper.Map<Models.TipoConteiner>(tipoDto);
            StringUtils.ClassToUpper(tipo);
            tipo.TipoConteinerUuid = Guid.NewGuid();
            tipo.Status = true;

            if (tipo is null)
            {
                throw new CadastrarTipoConteinerException("Tipo de conteiner inválido. Erro ao cadastrar um tipo.");
            }

            _context.TipoConteinerRepository.Add(tipo);
            await _context.Commit();
            return tipo.TipoConteinerUuid;
        }

        public async Task PutTipo(AtualizaTipoConteinerViewModel tipoDto)
        {

            if (tipoDto.TipoConteinerUuid == Guid.Empty)
            {
                throw new AtualizarTipoConteinerException("Tipo de conteiner inválido. Erro ao atualizar o tipo.");
            }

            var tipo = await _context.TipoConteinerRepository.GetByParameter(p => p.TipoConteinerUuid == tipoDto.TipoConteinerUuid);

            if (tipo == null)
            {
                throw new AtualizarTipoConteinerException("Tipo não encontrado. Erro ao atualizar o tipo.");
            }

            if (tipo.TipoConteineroId != 0)
            {
                var tipoMap = _mapper.Map<Models.TipoConteiner>(tipoDto);
                var tipoBase = await _context.TipoConteinerRepository.GetByParameter(p => p.TipoConteinerUuid == tipoMap.TipoConteinerUuid);
                tipoMap.Status = tipoBase.Status;
                StringUtils.ClassToUpper(tipoMap);
                tipoMap.TipoConteineroId = tipo.TipoConteineroId;

                _context.TipoConteinerRepository.Update(tipoMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarTipoConteinerException("Tipo conteiner inválido. Erro ao atualizar o tipo.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var tipo = await _context.TipoConteinerRepository.GetByParameter(p => p.TipoConteinerUuid == uuid);

            if (tipo == null)
            {
                throw new TipoConteinerNaoEncontradoException("Tipo conteiner não encontrado.");
            }

            tipo.Status = status;

            _context.TipoConteinerRepository.Update(tipo);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaTipoConteinerViewModel>(tipo);
        }
    }
}
