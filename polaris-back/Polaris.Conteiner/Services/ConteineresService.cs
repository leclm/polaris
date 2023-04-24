using AutoMapper;
using Polaris.Conteiner.Enums;
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
        private readonly ICategoriasConteinerService _categoriaService;
        private readonly ITiposConteineresService _tipoService;
        private readonly ICategoriaConteinerRepository _categoriaRepository;
        private readonly ITipoConteinerRepository _tipoRepository;

        public ConteineresService(IUnityOfWork context, IMapper mapper, ICategoriasConteinerService categoriaService, ITiposConteineresService tipoService)
        {
            _context = context;
            _mapper = mapper;
            _categoriaService = categoriaService;
            _tipoService = tipoService;
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
                throw new ConteinerNaoEncontradoException("Não há conteineres ativos.");
            }
            var conteineresDto = _mapper.Map<List<RetornoConteinerViewModel>>(conteineres);
            return conteineresDto;
        }

        public async Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAtivosDisponiveis()
        {
            var conteineres = _context.ConteinerRepository.GetConteineresAtivosDisponiveis();
            if (!conteineres.Any())
            {
                throw new ConteinerNaoEncontradoException("Não há conteineres ativos e/ou disponíveis.");
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

            if (conteinerDto.Categoria != Guid.Empty)
            {
                var categoria = await _context.CategoriaConteinerRepository.GetByParameter(x => x.CategoriaConteinerUuid == conteinerDto.Categoria); 
                if (categoria != null && categoria.Status != false)
                {
                    conteiner.CategoriaConteinerId = categoria.CategoriaConteinerId;
                }
                else
                {
                    throw new CadastrarConteinerException("Categoria inválida. Erro ao cadastrar o conteiner.");
                }
            }
            else
            {
                throw new CadastrarConteinerException("Categoria inválida. Erro ao cadastrar o conteiner.");
            }


            if (conteinerDto.Tipo != Guid.Empty)
            {
                var tipo = await _context.TipoConteinerRepository.GetByParameter(x => x.TipoConteinerUuid == conteinerDto.Tipo);
                if (tipo != null && tipo.Status != false)
                {
                    conteiner.TipoConteinerId = tipo.TipoConteineroId;
                }
                else
                {
                    throw new CadastrarConteinerException("Tipo inválido. Erro ao cadastrar o conteiner.");
                }
            }
            else
            {
                throw new CadastrarConteinerException("Tipo inválido. Erro ao cadastrar o conteiner.");
            }

            conteiner.Estado = EstadoConteiner.Disponível;
            conteiner.Status = true;
          
            _context.ConteinerRepository.Add(conteiner); 
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

            if (conteiner == null || conteiner.ConteinerId == 0)
            {
                throw new ConteinerNaoEncontradoException("Conteiner não encontrado. Erro ao atualizar o conteiner.");
            }
            else
            {
                conteiner.Fabricacao = conteinerDto.Fabricacao;
                conteiner.Fabricante = conteinerDto.Fabricante;
                conteiner.Material = conteinerDto.Material;
                conteiner.Cor = conteinerDto.Cor;
                conteiner.Estado = conteinerDto.Estado;
                StringUtils.ClassToUpper(conteiner);
            }

            if ((int)conteinerDto.Estado < 0 || (int)conteinerDto.Estado > 8)
            {
                throw new AtualizarConteinerException("Estado do conteiner inválido. Erro ao atualizar o conteiner.");
            }

            if (conteinerDto.Categoria != Guid.Empty)
            {
                var categoria = await _context.CategoriaConteinerRepository.GetByParameter(x => x.CategoriaConteinerUuid == conteinerDto.Categoria);
                if (categoria != null && categoria.Status != false )
                {
                    conteiner.CategoriaConteinerId = categoria.CategoriaConteinerId;
                }
                else
                {
                    throw new AtualizarConteinerException("Categoria inválida. Erro ao atualizar o conteiner.");
                }
            }
            else { throw new AtualizarConteinerException("Categoria inválida. Erro ao atualizar o conteiner."); }

            if (conteinerDto.Tipo != Guid.Empty)
            {
                var tipo = await _context.TipoConteinerRepository.GetByParameter(x => x.TipoConteinerUuid == conteinerDto.Tipo);
                if (tipo != null && tipo.Status != false)
                {
                    conteiner.TipoConteinerId = tipo.TipoConteineroId;
                }
                else
                {
                    throw new AtualizarConteinerException("Tipo inválido. Erro ao atualizar o conteiner.");
                }
            }
            else 
            {
                throw new AtualizarConteinerException("Tipo inválido. Erro ao atualizar o conteiner."); 
            }

            _context.ConteinerRepository.Update(conteiner);
            await _context.Commit();
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

        public async Task AlterarDisponibilidade(Guid uuid, EstadoConteiner estado)
        {
            var conteiner = await _context.ConteinerRepository.GetByParameter(p => p.ConteinerUuid == uuid);

            if (conteiner == null)
            {
                throw new ConteinerNaoEncontradoException("Conteiner não encontrado.");
            }

            conteiner.Estado = estado;

            _context.ConteinerRepository.Update(conteiner);
            await _context.Commit();
        }
    }
}
