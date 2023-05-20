using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.ViewModels
{
    public class BuscaServicoViewModel
    {
        public Guid ServicoUuid { get; set; }
        public string? Nome { get; set; }
    }
}
