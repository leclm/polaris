namespace Polaris.TipoConteiner.Exceptions
{

    [Serializable]
    public class CustomExceptions
    {
        public class TipoConteinerNaoEncontradoException : Exception
        {
            public TipoConteinerNaoEncontradoException() { }

            public TipoConteinerNaoEncontradoException(string message)
                : base(message) { }
        }
        public class CadastrarTipoConteinerException : Exception
        {
            public CadastrarTipoConteinerException() { }

            public CadastrarTipoConteinerException(string message)
                : base(message) { }
        }
        public class AtualizarTipoConteinerException : Exception
        {
            public AtualizarTipoConteinerException() { }

            public AtualizarTipoConteinerException(string message)
                : base(message) { }
        }
    }
}
