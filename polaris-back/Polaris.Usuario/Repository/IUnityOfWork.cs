namespace Polaris.Usuario.Repository
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
