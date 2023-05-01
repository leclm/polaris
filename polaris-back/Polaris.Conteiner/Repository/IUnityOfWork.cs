namespace Polaris.Conteiner.Repository
{
    public interface IUnityOfWork
    {
        ITipoConteinerRepository TipoConteinerRepository { get; }
        ICategoriaConteinerRepository CategoriaConteinerRepository { get; }
        IConteinerRepository ConteinerRepository { get; }
        IPrestacaoServicoRepository PrestacaDeServicoRepository { get; }
        ITerceirizadoRepository TerceirizadoRepository { get; }
        Task Commit();
    }
}
