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
    }
}
