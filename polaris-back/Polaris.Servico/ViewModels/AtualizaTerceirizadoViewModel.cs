using Polaris.Servico.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.ViewModels
{
    public class AtualizaTerceirizadoViewModel
    {
        public Guid TerceirizadoUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um CNPJ.")]
        [MaxLength(18, ErrorMessage = " Erro. CNPJ inválido.")]
        [NotNull]
        [Required]
        public string? Cnpj { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma empresa.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Empresa { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um e-mail.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Email { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um telefone.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Telefone { get; set; }
        [Required]
        [NotNull]
        public AtualizaEnderecoViewModel? Endereco { get; set; }
        public IEnumerable<Guid>? ListaServicos { get; set; }
    }
}
