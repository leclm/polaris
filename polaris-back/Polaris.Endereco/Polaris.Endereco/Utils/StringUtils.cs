namespace Polaris.Endereco.Utils
{
    public static class StringUtils
    {
        public static void ClassToUpper(Models.Endereco endereco)
        {
            endereco.Logradouro = endereco.Logradouro.ToUpper();
            endereco.Cidade = endereco.Cidade.ToUpper();
            endereco.Estado = endereco.Estado.ToUpper();
            endereco.Complemento = endereco.Complemento.ToUpper();
        }
    }
}
