namespace Polaris.Servico.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.Terceirizado terceirizado)
        {
            terceirizado.Empresa = terceirizado.Empresa.ToUpper();
        }

        public static void ClassToUpper(Models.Servico servico)
        {
            servico.Nome = servico.Nome.ToUpper();
        }
    }
}