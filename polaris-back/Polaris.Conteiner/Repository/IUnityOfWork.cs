namespace Polaris.Conteiner.Repository
{
    public interface IUnityOfWork
    {
        ITipoConteinerRepository TipoConteinerRepository { get; }
        ICategoriaConteinerRepository CategoriaConteinerRepository { get; }
        IConteinerRepository ConteinerRepository { get; }
        IPrestacaoServicoRepository PrestacaDeServicoRepository { get; }
        Task Commit();
    }
}
