using Polaris.Usuario.Models;

namespace Polaris.Usuario.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.Cliente cliente)
        {
            cliente.Nome = cliente.Nome.ToUpper();
            cliente.Sobrenome = cliente.Sobrenome.ToUpper();
            cliente.Email = cliente.Email.ToUpper();
        }

        public static void ClassToUpper(Models.Gerente gerente)
        {
            gerente.Empresa = gerente.Empresa.ToUpper();
            gerente.Email = gerente.Email.ToUpper();
        }
        public static void ClassToUpper(Models.Login login)
        {
            login.Usuario = login.Usuario.ToUpper();
        }
    }
}