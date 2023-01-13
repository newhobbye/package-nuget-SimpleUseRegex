using System.Text.RegularExpressions;

namespace TestRegex
{
    public static class SubFunctions
    {

        public static string[] RemoveWriteSpaceInPhoneBr(string[] input)
        {
            string pattern = @" ";
            string[] result = new string[input.Length];

            RegexOptions options = RegexOptions.IgnoreCase;
            Regex rx = new Regex(pattern, options);

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = rx.Replace(input[i], string.Empty);
            }

            return result;
        }
    }
}
