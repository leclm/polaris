namespace Polaris.Usuario.Exceptions
{
    [Serializable]
    public class CustomExceptions
    {
        public class LoginNaoEncontradoException : Exception
        {
            public LoginNaoEncontradoException() { }

            public LoginNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarLoginException : Exception
        {
            public CadastrarLoginException() { }

            public CadastrarLoginException(string message)
                : base(message) { }
        }
        public class AtualizarLoginException : Exception
        {
            public AtualizarLoginException() { }

            public AtualizarLoginException(string message)
                : base(message) { }
        }

        public class LogarException : Exception
        {
            public LogarException() { }

            public LogarException(string message)
                : base(message) { }
        }
    }
}
