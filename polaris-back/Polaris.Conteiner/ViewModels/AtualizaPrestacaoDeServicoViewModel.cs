using Polaris.Conteiner.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.ViewModels
{
    public class AtualizaPrestacaoDeServicoViewModel
    {
        public Guid PrestacaoDeServicoUuid { get; set; }
        [NotNull]
        [Required]
        public DateTime DataProcedimento { get; set; }
        [MaxLength(200, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        public string? Comentario { get; set; }
        [NotNull]
        [Required]
        public Guid Conteiner { get; set; }
        [NotNull]
        [Required]
        public Guid Tercerizado { get; set; }
        [NotNull]
        [Required]
        public Guid Servico { get; set; }
    }
}
