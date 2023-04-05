using System.Net.Mail;

namespace Polaris.Servico.Validation
{
    public class ValidaEmail
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }

            return MailAddress.TryCreate(email, out var addr)
                && addr.Address == trimmedEmail;
        }
    }
}
