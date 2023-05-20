namespace Polaris.Aluguel.ViewModels
{
    public class BuscaClienteViewModel
    {
        public Guid ClienteUuid { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
    }
}
