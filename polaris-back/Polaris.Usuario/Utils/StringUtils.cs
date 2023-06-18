using Polaris.Usuario.Models;

namespace Polaris.Usuario.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.Cliente cliente)
        {
            cliente.Nome = cliente.Nome.ToUpper();
            cliente.Sobrenome = cliente.Sobrenome.ToUpper();
        }

        public static void ClassToUpper(Models.Gerente gerente)
        {
            gerente.Empresa = gerente.Empresa.ToUpper();
        }
    }
}