namespace Polaris.Conteiner.ExternalServices
{
    public interface IServicoExternalService
    {
        Task<Models.Servico> GetServicos(Guid uuid);
    }
}
