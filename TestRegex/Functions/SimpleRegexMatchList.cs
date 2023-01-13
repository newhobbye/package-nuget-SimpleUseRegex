using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexMatchList
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

        public static string[] GetEmailsInStringInput(string input)
        {
            
            string pattern = @"((\w+@)(\w+)\.(\w{3})?(\.\w{2})?)";

            Regex regex = new(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;
        }

        public static string[] GetCPFBrazilianIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{3}\.\d{3}.\d{3}-\d{2})";

            Regex regex = new(pattern, RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;
        }

        public static string[] GetRGBrazilianIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{2})\.(\d{3})\.(\d{3})(\s?-?\d{1})?";

            Regex regex = new(pattern, RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;

        }

        //ceps

        //cnpjs

        //tags html
    }
}
