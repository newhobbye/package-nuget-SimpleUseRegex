using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SubFunctions
    {

        public static bool RemoveWritespaceOnBrazilianPhones(string[] input, out string[] result)
        {
            if (input == null)
            {
                result = null;
                return false;
            }
            string pattern = @" ";
            result = new string[input.Length];

            var options = RegexOptions.Multiline;
            var rx = new Regex(pattern, options);

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = rx.Replace(input[i], string.Empty);
            }

            return true;
        }

        public static bool RemoveMaskCPF(string cpf, out string output)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1$2$3$4";

            var regex = new Regex(pattern);

            output = regex.Replace(cpf, subistituition);

            if(output.Length != 11)
            {
                return false;
            }

            return true;

        }

        
    }
}
