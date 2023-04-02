namespace Polaris.Servico.Repository
{
    public interface IUnityOfWork
    {
        IServicoRepository ServicoRepository { get; }
        ITerceirizadoRepository TerceirizadoRepository { get; }
        Task Commit();
    }
}
