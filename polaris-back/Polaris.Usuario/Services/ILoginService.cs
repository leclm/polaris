using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.Services
{
    public interface ILoginService
    {
        Task<RetornoLoginViewModel> Logar(CadastroLoginViewModel loginDto);
        Task<Guid> CadastrarLogin(CadastroLoginViewModel loginDto);
        Task PutLogin(AtualizaLoginViewModel loginDto);
        Task AlterarStatus(Guid uuid, bool status);
        Task AlterarSenha(AlteraSenha loginDto);
    }
}
