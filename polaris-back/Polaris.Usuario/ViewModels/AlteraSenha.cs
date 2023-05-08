using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class AlteraSenha
    {
        public Guid LoginUuid { get; set; }
    
        [MinLength(1, ErrorMessage = "Erro. Digite uma senha.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Senha { get; set; }
    }
}
