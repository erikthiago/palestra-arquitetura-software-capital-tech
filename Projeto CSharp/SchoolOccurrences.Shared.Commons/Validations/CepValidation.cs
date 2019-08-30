using System.Text.RegularExpressions;

namespace SchoolOccurrences.Shared.Commons.Validations
{
    public abstract class CepValidation
    {
        public static bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}-\d{3}$");

            if (!Rgx.IsMatch(cep))
                return false;
            else
                return true;
        }
    }
}
