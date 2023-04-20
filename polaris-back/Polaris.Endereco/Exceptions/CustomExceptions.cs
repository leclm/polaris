namespace Polaris.Endereco.Exceptions
{
    [Serializable]
    public class CustomExceptions
    {
        public class EnderecoNaoEncontradoException : Exception
        {
            public EnderecoNaoEncontradoException() { }

            public EnderecoNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarEnderecoException : Exception
        {
            public CadastrarEnderecoException() { }

            public CadastrarEnderecoException(string message)
                : base(message) { }
        }
        public class AtualizarEnderecoException : Exception
        {
            public AtualizarEnderecoException() { }

            public AtualizarEnderecoException(string message)
                : base(message) { }
        }
    }
}
