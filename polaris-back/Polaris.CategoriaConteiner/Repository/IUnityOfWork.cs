namespace Polaris.CategoriaConteiner.Repository
{
    public interface IUnityOfWork
    {
        ICategoriaConteinerRepository CategoriaConteinerRepository { get; }
        Task Commit();
    }
}
