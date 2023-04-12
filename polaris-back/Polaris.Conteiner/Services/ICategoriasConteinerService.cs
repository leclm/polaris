using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public interface ICategoriasConteinerService
    {
        Task<IEnumerable<RetornoCategoriaConteinerViewModel>> GetCategorias();
        Task<RetornoCategoriaConteinerViewModel> GetCategoria(Guid uuid);
        Task<Guid> PostCategoria(CadastroCategoriaConteinerViewModel categoriaDto);
        Task PutCategoria(AtualizarCategoriaConteinerViewModel categoriaDto);
        Task AlterarStatus(Guid uuid, bool status);
    }
}
