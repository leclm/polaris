using System.Text.RegularExpressions;

namespace Polaris.Servico.Validation
{
    public class ValidaTelefone
    {
        public static bool IsTelefone(string telefone)
        {
            Regex Rgx = new Regex(@"^\(\d{2}\)\d{5}-\d{4}$"); //formato (XX)XXXXX-XXXX

            if (!Rgx.IsMatch(telefone))
                return false;
            else
                return true;
        }
    }
}
