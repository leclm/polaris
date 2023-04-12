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
    }
}
