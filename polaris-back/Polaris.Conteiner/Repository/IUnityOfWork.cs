namespace Polaris.Conteiner.Repository
{
    public interface IUnityOfWork
    {
        ITipoConteinerRepository TipoConteinerRepository { get; }
        ICategoriaConteinerRepository CategoriaConteinerRepository { get; }
        Task Commit();
    }
}
