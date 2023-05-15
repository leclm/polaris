using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ViewModels
{
    public class RetornoClienteViewModel
    {
        public Guid ClienteUuid { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool Status { get; set; }
        public RetornoEnderecoViewModel Endereco { get; set; }
    }
}
