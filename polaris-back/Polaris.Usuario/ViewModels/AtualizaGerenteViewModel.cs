using Polaris.Usuario.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class AtualizaGerenteViewModel
    {
        public Guid GerenteUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um CNPJ.")]
        [MaxLength(18, ErrorMessage = " Erro. CNPJ inválido.")]
        [NotNull]
        [Required]
        public string Cnpj { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma empresa.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Empresa { get; set; }     
        [MinLength(1, ErrorMessage = "Erro. Digite um telefone.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Telefone { get; set; }

        [NotNull]
        [Required]
        public AtualizaEnderecoViewModel? Endereco { get; set; }
        public AtualizaLoginViewModel Login { get; set; }
    }
}
