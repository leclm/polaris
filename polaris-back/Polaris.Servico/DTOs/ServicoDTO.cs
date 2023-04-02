using Polaris.Servico.Models;

namespace Polaris.Servico.DTOs
{
    public class ServicoDTO
    {
        public int ServicoId { get; set; }
        public string? Nome { get; set; }
        public bool Status { get; set; }
    }
}
