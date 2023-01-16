using System.Text.RegularExpressions;

namespace TestRegex
{
    public static class SimpleRegexFormat
    {

        public static string RemoveTagsInAnHTMLBody(string input)
        {
            string pattern = @"(<\w+.+?>)(\s+)?(.+?)(\s+)?(<\/\w+>)";
            string subistituition = @"$3";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string FormatBrazilianPhonesWithDDDByAStringInput(string input)
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string[] FormatBrazilianPhonesWithDDDByAListStringInput(string[] input)
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = regex.Replace(input[i], subistituition);
            }

            return result;
        }

    }
}
