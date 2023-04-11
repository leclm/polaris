namespace Polaris.CategoriaConteiner.Utils
{
    public class StringUtils
    {
        public static void ClassToUpper(Models.CategoriaConteiner categoriaConteiner)
        {
            categoriaConteiner.Nome = categoriaConteiner.Nome.ToUpper();
        }
    }
}
