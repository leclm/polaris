using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Repository;
using Polaris.Servico.ViewModels;
using static Polaris.Servico.Exceptions.CustomExceptions;

namespace Polaris.Servico.Services
{
    public class TerceirizadosService : ITerceirizadosService
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public TerceirizadosService(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados()
        {
            var terceirizados = await _context.TerceirizadoRepository.Get().ToListAsync();
            if (terceirizados is null)
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }
            var terceirizadosDto = _mapper.Map<List<RetornoTerceirizadoViewModel>>(terceirizados);
            return terceirizadosDto;
        }

        public async Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetById(p => p.TerceirizadoUuid == uuid);

            if (terceirizado is null)
            {
                throw new TerceirizadoNaoEncontradoException("Não há terceirizados cadastrados.");
            }
            var terceirizadoDto = _mapper.Map<RetornoTerceirizadoViewModel>(terceirizado);
            return terceirizadoDto;
        }

        public async Task<Guid> PostTerceirizado(CadastroTerceirizadoViewModel terceirizadoDto)
        {
            var terceirizado = _mapper.Map<Models.Terceirizado>(terceirizadoDto);
            terceirizado.TerceirizadoUuid = Guid.NewGuid();
            terceirizado.Status = true;

            if (terceirizado is null)
            {
                throw new CadastrarTerceirizadoException("Terceirizado inválido. Erro ao cadastrar um terceirizado.");
            }

            _context.TerceirizadoRepository.Add(terceirizado);
            await _context.Commit();
            return terceirizado.TerceirizadoUuid;
        }

        public async Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto)
        {

            if (terceirizadoDto.TerceirizadoUuid == Guid.Empty)
            {
                throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
            }

            var terceirizado = await _context.TerceirizadoRepository.GetById(p => p.TerceirizadoUuid == terceirizadoDto.TerceirizadoUuid);

            if (terceirizado.TerceirizadoId != 0)
            {
                var terceirizadoMap = _mapper.Map<Models.Terceirizado>(terceirizadoDto);
                terceirizadoMap.TerceirizadoId = terceirizado.TerceirizadoId;

                _context.TerceirizadoRepository.Update(terceirizadoMap);
                await _context.Commit();
            }
            else
            {
                throw new AtualizarTerceirizadoException("Terceirizado inválido. Erro ao atualizar o terceirizado.");
            }
        }

        public async Task AlterarStatus(Guid uuid, bool status)
        {
            var terceirizado = await _context.TerceirizadoRepository.GetById(p => p.TerceirizadoUuid == uuid);

            if (terceirizado == null)
            {
                throw new TerceirizadoNaoEncontradoException("Terceirizado não encontrado.");
            }

            terceirizado.Status = status;

            _context.TerceirizadoRepository.Update(terceirizado);
            await _context.Commit();

            var enderecoDto = _mapper.Map<AtualizaTerceirizadoViewModel>(terceirizado);
        }
    }
}
