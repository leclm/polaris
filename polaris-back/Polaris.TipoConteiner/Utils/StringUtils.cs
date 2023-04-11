namespace Polaris.TipoConteiner.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.TipoConteiner tipoConteiner)
        {
            tipoConteiner.Nome = tipoConteiner.Nome.ToUpper();
        }
    }
}
