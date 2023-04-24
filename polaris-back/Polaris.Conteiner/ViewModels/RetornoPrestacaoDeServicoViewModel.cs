using Polaris.Conteiner.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.ViewModels
{
    public class RetornoPrestacaoDeServicoViewModel
    {
        public Guid PrestacaoDeServicoUuid { get; set; }
        [NotNull]
        [Required]
        public ServicoStatus Status { get; set; }
        [NotNull]
        [Required]
        public DateTime DataProcedimento { get; set; }
        [MaxLength(200, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        public string? Comentario { get; set; }
        [NotNull]
        [Required]
        public RetornoConteinerViewModel Conteiner { get; set; }
        [NotNull]
        [Required]
        public Models.Terceirizado Tercerizado { get; set; }
        [NotNull]
        [Required]
        public Models.Servico Servico { get; set; }
    }
}
