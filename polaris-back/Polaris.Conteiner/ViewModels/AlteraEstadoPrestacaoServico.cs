using Polaris.Conteiner.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.ViewModels
{
    public class AlteraEstadoPrestacaoServico
    {
        public Guid PrestacaoDeServicoUuid { get; set; }
        [NotNull]
        [Required]
        public DateTime DataProcedimento { get; set; }
        [NotNull]
        [Required]
        public EstadoPrestacaoServico EstadoPrestacaoServico { get; set; }
        [MaxLength(200, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        public string? Comentario { get; set; }
    }
}
