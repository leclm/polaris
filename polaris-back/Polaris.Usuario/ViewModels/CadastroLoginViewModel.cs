using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class CadastroLoginViewModel
    {
        public CadastroLoginViewModel(CadastroClienteViewModel clienteDto)
        {
            Usuario = clienteDto.Email;
            Senha = clienteDto.DataNascimento.ToString("ddMMyyyy");
        }

        public CadastroLoginViewModel(CadastroGerenteViewModel gerenteDto)
        {
            Usuario = gerenteDto.Email;
            Senha = gerenteDto.Cnpj;
        }

        [MinLength(1, ErrorMessage = "Erro. Digite um usuário válido.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Usuario { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma senha.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Senha { get; set; }
    }
}
