using System.Text.RegularExpressions;

namespace TestRegex
{
    public static class Replaces
    {
        public static string[] GetPhonesBRInString(string input)
        {
            string pattern = @"((\(?\d{2}\)?)\s?)?(9{1})?\s?((\d{4,5})-?\d{4})";
            Regex rx = new (pattern, RegexOptions.Multiline);
            MatchCollection matches = rx.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            result = SubFunctions.RemoveWriteSpaceInPhoneBr(result);

            return result;
        }
    }
}
