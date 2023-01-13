using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class Replaces
    {
        public static string[] PickUpBrazilianPhonesOnAStringInput(string input)
        {
            if (input == null) return new string[input.Length];

            string pattern = @"((\(?\d{2}\)?)\s?)?(9{1})?\s?((\d{4,5})-?\d{4})";
            Regex rx = new(pattern, RegexOptions.Multiline);
            MatchCollection matches = rx.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            if (SubFunctions.RemoveWritespaceOnBrazilianPhones(result, out result))
            {
                return result;
            }
            else
            {
                result = new string[0];
                return result;
            }

        }
    }
}
