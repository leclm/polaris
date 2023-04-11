namespace Polaris.TipoConteiner.Repository
{
    public interface IUnityOfWork
    {
        ITipoConteinerRepository TipoConteinerRepository { get; }
        Task Commit();
    }
}
