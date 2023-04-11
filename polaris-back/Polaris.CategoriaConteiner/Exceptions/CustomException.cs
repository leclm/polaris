namespace Polaris.CategoriaConteiner.Exceptions
{
    public class CustomException
    {
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
