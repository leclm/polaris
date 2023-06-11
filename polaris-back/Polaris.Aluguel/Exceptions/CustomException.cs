namespace Polaris.Aluguel.Exceptions
{
    [Serializable]
    public class CustomExceptions
    {
        public class AluguelNaoEncontradoException : Exception
        {
            public AluguelNaoEncontradoException() { }

            public AluguelNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarAluguelException : Exception
        {
            public CadastrarAluguelException() { }

            public CadastrarAluguelException(string message)
                : base(message) { }
        }
        public class AtualizarAluguelException : Exception
        {
            public AtualizarAluguelException() { }

            public AtualizarAluguelException(string message)
                : base(message) { }
        }

        public class PagamentoPayPalException : Exception
        {
            public PagamentoPayPalException() { }

            public PagamentoPayPalException(string message)
                : base(message) { }
        }
    }
}
