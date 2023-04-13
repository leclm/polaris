using AutoMapper;
using Polaris.Conteiner.Models;
using Polaris.Conteiner.Repository;
using Polaris.Conteiner.Utils;
using Polaris.Conteiner.ViewModels;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Services
{
    public class ConteineresService : IConteineresService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public ConteineresService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresPorCategoria(string categoria)
        {
            var conteineres = _context.ConteinerRepository.GetConteineresPorCategoria(categoria);
            if (!conteineres.Any())
            {
                throw new ConteinerNaoEncontradoException("Nenhum resultado encontrado.");
            }
            var conteineresDto = _mapper.Map<List<RetornoConteinerViewModel>>(conteineres);
            return conteineresDto;
        }
        public async Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresPorTipo(string tipo)
        {
            var conteineres = _context.ConteinerRepository.GetConteineresPorTipo(tipo);
            if (!conteineres.Any())
            {
                throw new ConteinerNaoEncontradoException("Nenhum resultado encontrado.");
            }
            var conteineresDto = _mapper.Map<List<RetornoConteinerViewModel>>(conteineres);
            return conteineresDto;
        }

        public async Task<IEnumerable<RetornoConteinerViewModel>> GetConteineres()
        {
            var conteineres = _context.ConteinerRepository.GetConteineresCompleto();
            if (!conteineres.Any())
            {
                throw new ConteinerNaoEncontradoException("Não há conteineres cadastrados.");
            }
            var conteineresDto = _mapper.Map<List<RetornoConteinerViewModel>>(conteineres);
            return conteineresDto;
        }

        public async Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAtivos()
        {
            var conteineres = _context.ConteinerRepository.GetConteineresAtivosCompleto();
            if (!conteineres.Any())
            {
                throw new ConteinerNaoEncontradoException("Não há conteineres cadastrados.");
            }
            var conteineresDto = _mapper.Map<List<RetornoConteinerViewModel>>(conteineres);
            return conteineresDto;
        }

        public async Task<RetornoConteinerViewModel> GetConteiner(Guid uuid)
        {
            var conteiner = await _context.ConteinerRepository.GetConteiner(uuid);

            if (conteiner is null)
            {
                throw new ConteinerNaoEncontradoException("Não há conteineres cadastrados.");
            }
            var conteinerDto = _mapper.Map<RetornoConteinerViewModel>(conteiner);
            return conteinerDto;
        }

        public async Task<Guid> PostConteiner(CadastroConteinerViewModel conteinerDto)
        {
            if (await _context.ConteinerRepository.GetByParameter(x => x.Codigo == conteinerDto.Codigo) is not null)
            {
                throw new CadastrarConteinerException("Conteiner já existe. Erro ao cadastrar um conteiner.");
            };

            var conteiner = _mapper.Map<Models.Conteiner>(conteinerDto);
            StringUtils.ClassToUpper(conteiner);
            conteiner.ConteinerUuid = Guid.NewGuid();
            conteiner.Disponivel = true;
            conteiner.Status = true;

            _context.ConteinerRepository.Add(conteiner);
            await _context.Commit();

            foreach (var categoriaUuid in conteinerDto!.ListaCategorias!)
            {
                var categoria = await _context.CategoriaConteinerRepository.GetByParameter(x => x.CategoriaConteinerUuid == categoriaUuid);
                conteiner!.CategoriasConteineres!.Add(categoria);
            }

            foreach (var tipoUuid in conteinerDto!.ListaTipos!)
            {
                var tipo = await _context.TipoConteinerRepository.GetByParameter(x => x.TipoConteinerUuid == tipoUuid);
                conteiner!.TiposConteineres!.Add(tipo);
            }

            await _context.Commit();
            return conteiner.ConteinerUuid;
        }

        public async Task PutConteiner(AtualizaConteinerViewModel conteinerDto)
        {
            if (conteinerDto.ConteinerUuid == Guid.Empty)
            {
                throw new AtualizarConteinerException("Conteiner inválido. Erro ao atualizar o conteiner.");
            }

            var conteiner = await _context.ConteinerRepository.GetByParameter(p => p.ConteinerUuid == conteinerDto.ConteinerUuid);

            if (conteiner == null)
            {
                throw new ConteinerNaoEncontradoException("Conteiner não encontrado. Erro ao atualizar o conteiner.");
            }

            if (conteiner.ConteinerId != 0)
            {
                var conteinerMap = _mapper.Map<Models.Conteiner>(conteinerDto);
                var conteinerBase = await _context.ConteinerRepository.GetByParameter(p => p.ConteinerUuid == conteinerMap.ConteinerUuid);
                conteinerMap.Status = conteinerBase.Status;
                StringUtils.ClassToUpper(conteinerMap);
                conteinerMap.ConteinerId = conteiner.ConteinerId;
                _context.ConteinerRepository.Update(conteinerMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarConteinerException("Conteiner inválido. Erro ao atualizar o conteiner.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var conteiner = await _context.ConteinerRepository.GetByParameter(p => p.ConteinerUuid == uuid);

            if (conteiner == null)
            {
                throw new ConteinerNaoEncontradoException("Conteiner não encontrado.");
            }

            conteiner.Status = status;

            _context.ConteinerRepository.Update(conteiner);
            await _context.Commit();
        }
    }
}
