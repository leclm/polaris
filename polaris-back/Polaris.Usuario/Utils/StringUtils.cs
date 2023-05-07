namespace Polaris.Usuario.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.Cliente cliente)
        {
            //cliente.Empresa = terceirizado.Empresa.ToUpper();
        }

        public static void ClassToUpper(Models.Gerente gerente)
        {
            //servico.Nome = servico.Nome.ToUpper();
        }
        public static void ClassToUpper(Models.Login login)
        {
            login.Usuario = login.Usuario.ToUpper();
        }
    }
}