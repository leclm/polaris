namespace Polaris.Usuario.Repository
{
    public interface IUnityOfWork
    {
        ILoginRepository LoginRepository { get; }
        IClienteRepository ClienteRepository { get; }
        public IGerenteRepository GerenteRepository { get; }
        Task Commit();
    }
}
