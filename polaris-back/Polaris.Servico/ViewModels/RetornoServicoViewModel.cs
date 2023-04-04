using Polaris.Servico.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.ViewModels
{
    public class RetornoServicoViewModel
    {
        public Guid ServicoUuid { get; set; }
        public string? Nome { get; set; }
        public bool Status { get; set; }
    }
}
