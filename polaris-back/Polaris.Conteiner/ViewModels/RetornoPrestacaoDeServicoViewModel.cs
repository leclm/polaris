using Polaris.Conteiner.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.ViewModels
{
    public class RetornoPrestacaoDeServicoViewModel
    {
        public Guid PrestacaoDeServicoUuid { get; set; }
        public DateTime DataProcedimento { get; set; }
        public EstadoPrestacaoServico EstadoPrestacaoServico { get; set; }
        public string? Comentario { get; set; }
        public RetornoConteinerViewModel Conteiner { get; set; }
        public RetornoTerceirizadoViewModel Terceirizado { get; set; }
        public BuscaServicoViewModel Servico { get; set; }
    }
}
