namespace Polaris.Usuario.Repository
{
    public interface IUnityOfWork
    {
        ILoginRepository LoginRepository { get; }
        Task Commit();
    }
}
