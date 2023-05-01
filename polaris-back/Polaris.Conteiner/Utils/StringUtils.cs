namespace Polaris.Conteiner.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.TipoConteiner tipoConteiner)
        {
            tipoConteiner.Nome = tipoConteiner.Nome.ToUpper();
        }

        public static void ClassToUpper(Models.CategoriaConteiner categoriaConteiner)
        {
            categoriaConteiner.Nome = categoriaConteiner.Nome.ToUpper();
        }

        public static void ClassToUpper(Models.PrestacaoDeServico prestacao)
        {
            prestacao.Comentario = prestacao.Comentario.ToUpper();
        }

        public static void ClassToUpper(Models.Conteiner conteiner)
        {
            conteiner.Cor = conteiner.Cor.ToUpper();
            conteiner.Fabricante = conteiner.Fabricante.ToUpper();
            conteiner.Material = conteiner.Material.ToUpper();
        }
    }
}
