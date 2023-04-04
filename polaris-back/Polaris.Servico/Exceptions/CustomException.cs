namespace Polaris.Servico.Exceptions
{
    [Serializable]
    public class CustomExceptions
    {
        public class ServicoNaoEncontradoException : Exception
        {
            public ServicoNaoEncontradoException() { }

            public ServicoNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarServicoException : Exception
        {
            public CadastrarServicoException() { }

            public CadastrarServicoException(string message)
                : base(message) { }
        }
        public class AtualizarServicoException : Exception
        {
            public AtualizarServicoException() { }

            public AtualizarServicoException(string message)
                : base(message) { }
        }

        public class TerceirizadoNaoEncontradoException : Exception
        {
            public TerceirizadoNaoEncontradoException() { }

            public TerceirizadoNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarTerceirizadoException : Exception
        {
            public CadastrarTerceirizadoException() { }

            public CadastrarTerceirizadoException(string message)
                : base(message) { }
        }
        public class AtualizarTerceirizadoException : Exception
        {
            public AtualizarTerceirizadoException() { }

            public AtualizarTerceirizadoException(string message)
                : base(message) { }
        }
    }
}
