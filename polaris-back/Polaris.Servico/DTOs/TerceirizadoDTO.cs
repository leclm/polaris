using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.DTOs
{
    public class TerceirizadoDTO
    {
        public int TerceirizadoId { get; set; }
        public string? Cnpj { get; set; }
        public string? Empresa { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool Status { get; set; }
    }
}
