namespace Polaris.Aluguel.Repository
{
    public interface IUnityOfWork
    {
        IAluguelRepository AluguelRepository { get; }
        Task Commit();
    }
}
