using Polaris.Usuario.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class CadastroGerenteViewModel
    {
        public string Cnpj { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma empresa.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Empresa { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um e-mail.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Email { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um telefone.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Telefone { get; set; }

        [Required]
        [NotNull]
        public CadastroEnderecoViewModel Endereco { get; set; }
    }
}
