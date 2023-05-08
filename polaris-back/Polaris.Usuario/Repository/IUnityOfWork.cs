namespace Polaris.Usuario.Repository
{
    public interface IUnityOfWork
    {
        ILoginRepository LoginRepository { get; }
        IClienteRepository ClienteRepository { get; }
        Task Commit();
    }
}
