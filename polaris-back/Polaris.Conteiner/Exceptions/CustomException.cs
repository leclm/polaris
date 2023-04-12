namespace Polaris.Conteiner.Exceptions
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

        public class CategoriaConteinerNaoEncontradaException : Exception
        {
            public CategoriaConteinerNaoEncontradaException() { }

            public CategoriaConteinerNaoEncontradaException(string message)
                : base(message) { }
        }
        public class CadastraCategoriaConteinerException : Exception
        {
            public CadastraCategoriaConteinerException() { }

            public CadastraCategoriaConteinerException(string message)
                : base(message) { }
        }
        public class AtualizarCategoriaConteinerException : Exception
        {
            public AtualizarCategoriaConteinerException() { }

            public AtualizarCategoriaConteinerException(string message)
                : base(message) { }
        }
    }
}
