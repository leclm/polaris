using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Repository;
using Polaris.Conteiner.Utils;
using Polaris.Conteiner.ViewModels;
using static Polaris.Conteiner.Exceptions.CustomExceptions;

namespace Polaris.Conteiner.Services
{
    public class CategoriasConteinerService : ICategoriasConteinerService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public CategoriasConteinerService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RetornoCategoriaConteinerViewModel>> GetCategorias()
        {
            var categorias = await _context.CategoriaConteinerRepository.Get().ToListAsync();
            if (categorias is null)
            {
                throw new CategoriaConteinerNaoEncontradaException("Não há categorias cadastradas.");
            }
            var categoriasDto = _mapper.Map<List<RetornoCategoriaConteinerViewModel>>(categorias);
            return categoriasDto;
        }

        public async Task<RetornoCategoriaConteinerViewModel> GetCategoria(Guid uuid)
        {
            var categoria = await _context.CategoriaConteinerRepository.GetByParameter(p => p.CategoriaConteinerUuid == uuid);

            if (categoria is null)
            {
                throw new CategoriaConteinerNaoEncontradaException("Categoria não existe.");
            }
            var servicoDto = _mapper.Map<RetornoCategoriaConteinerViewModel>(categoria);
            return servicoDto;
        }

        public async Task<IEnumerable<RetornoCategoriaConteinerViewModel>> GetCategoriasAtivas()
        {
            var categorias = _context.CategoriaConteinerRepository.GetAllByParameter(x => x.Status == true);
            if (!categorias.Any())
            {
                throw new CategoriaConteinerNaoEncontradaException("Não há categorias ativas.");
            }
            return _mapper.Map<List<RetornoCategoriaConteinerViewModel>>(categorias);
        }

        public async Task<Guid> PostCategoria(CadastroCategoriaConteinerViewModel categoriaDto)
        {
            if (await _context.CategoriaConteinerRepository.GetByParameter(x => x.Nome == categoriaDto.Nome) is not null)
            {
                throw new CadastraCategoriaConteinerException("Categoria já existe. Erro ao cadastrar uma categoria.");
            };

            var categoria = _mapper.Map<Models.CategoriaConteiner>(categoriaDto);
            StringUtils.ClassToUpper(categoria);
            categoria.CategoriaConteinerUuid = Guid.NewGuid();
            categoria.Status = true;

            if (categoria is null)
            {
                throw new CadastraCategoriaConteinerException("Categoria inválida. Erro ao cadastrar uma categoria.");
            }

            _context.CategoriaConteinerRepository.Add(categoria);
            await _context.Commit();
            return categoria.CategoriaConteinerUuid;
        }

        public async Task PutCategoria(AtualizaCategoriaConteinerViewModel categoriaDto)
        {

            if (categoriaDto.CategoriaConteinerUuid == Guid.Empty)
            {
                throw new AtualizarCategoriaConteinerException("Categoria inválida. Erro ao atualizar a categoria.");
            }

            var categoria = await _context.CategoriaConteinerRepository.GetByParameter(p => p.CategoriaConteinerUuid == categoriaDto.CategoriaConteinerUuid);

            if (categoria == null)
            {
                throw new AtualizarCategoriaConteinerException("Categoria não encontrada. Erro ao atualizar a categoria.");
            }

            if (categoria.CategoriaConteinerId != 0)
            {
                var categoriaMap = _mapper.Map<Models.CategoriaConteiner>(categoriaDto);
                var categoriaBase = await _context.CategoriaConteinerRepository.GetByParameter(p => p.CategoriaConteinerUuid == categoriaMap.CategoriaConteinerUuid);
                categoriaMap.Status = categoriaBase.Status;
                StringUtils.ClassToUpper(categoria);
                categoriaMap.CategoriaConteinerId = categoria.CategoriaConteinerId;

                _context.CategoriaConteinerRepository.Update(categoriaMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarCategoriaConteinerException("Categoria inválida. Erro ao atualizar a categoria.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var categoria = await _context.CategoriaConteinerRepository.GetByParameter(p => p.CategoriaConteinerUuid == uuid);

            if (categoria == null)
            {
                throw new CategoriaConteinerNaoEncontradaException("Categoria não encontrada.");
            }

            categoria.Status = status;

            _context.CategoriaConteinerRepository.Update(categoria);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaCategoriaConteinerViewModel>(categoria);
        }
    }
}
