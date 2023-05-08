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


        public class ClienteNaoEncontradoException : Exception
        {
            public ClienteNaoEncontradoException() { }

            public ClienteNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarClienteException : Exception
        {
            public CadastrarClienteException() { }

            public CadastrarClienteException(string message)
                : base(message) { }
        }
        public class AtualizarClienteException : Exception
        {
            public AtualizarClienteException() { }

            public AtualizarClienteException(string message)
                : base(message) { }
        }


        public class GerenteNaoEncontradoException : Exception
        {
            public GerenteNaoEncontradoException() { }

            public GerenteNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarGerenteException : Exception
        {
            public CadastrarGerenteException() { }

            public CadastrarGerenteException(string message)
                : base(message) { }
        }
        public class AtualizarGerenteException : Exception
        {
            public AtualizarGerenteException() { }

            public AtualizarGerenteException(string message)
                : base(message) { }
        }
    }
}
