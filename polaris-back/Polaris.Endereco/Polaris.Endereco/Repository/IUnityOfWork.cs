namespace Polaris.Endereco.Repository
{
    public interface IUnityOfWork
    {
        IEnderecoRepository EnderecoRepository { get; }
        Task Commit();
    }
}
