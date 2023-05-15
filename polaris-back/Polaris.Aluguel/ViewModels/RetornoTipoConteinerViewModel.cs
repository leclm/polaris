using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Aluguel.ViewModels
{
    public class RetornoTipoConteinerViewModel
    {
        public Guid TipoConteinerUuid { get; set; }
        public string? Nome { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }
        public double Volume { get; set; }
        public double PesoMaximo { get; set; }
        public double Altura { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorMensal { get; set; }
        public bool Status { get; set; }
    }
}
