using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexMatchList
    {

        public static string[] SimpleUseMatchesListRegex(string expression, string input, RegexOptions flag)
        {
            var regex = new Regex(expression, flag);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;
        }

        public static string[] PickUpBrazilianPhonesOnAStringInput(string input)
        {
            if (input == null) return new string[input.Length];

            string pattern = @"((\(?\d{2}\)?)\s?)?(9{1})?\s?((\d{4,5})-?\d{4})";
            string[] result = SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            if (SubFunctions.RemoveWritespaceOnBrazilianPhones(result, out result))
            {
                return result;
            }
            else
            {
                 return Array.Empty<string>();
                
            }

        }

        public static string[] GetEmailsInStringInput(string input)
        {
            string pattern = @"((\w+@)(\w+)\.(\w{3})?(\.\w{2})?)";
            string[] result = SimpleUseMatchesListRegex(pattern, input, RegexOptions.IgnoreCase);

            if(result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetCPFBrazilianIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{3}\.\d{3}.\d{3}-\d{2})";
            string[] result = SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);
            
            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetRGBrazilianIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{2})\.(\d{3})\.(\d{3})(\s?-?\d{1})?";
            string[] result = SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            if (result == null) return new string[0];

            return result;

        }

        public static string[] GetBrazilianCEPOnStringInput(string input)
        {
            string pattern = @"\b(\d{5}-\d{3})\b"; //pattern que só pega se for separado
            //(\d{5}-\d{3}) = Pattern que pega até em meio a outros numeros e textos
            string[] result = SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;

        }

        public static string[] GetBrazilianCNPJIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})";
            string[] result = SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;

        }

        public static string[] GetIpValidFromStringInput(string input)
        {
            string pattern = @"\b(\d{1,2}|1\d{2}|2[0-4]\d|25[0-5])\b";
            string completeExpression = @$"{pattern}\.{pattern}\.{pattern}\.{pattern}";

            string[] result = SimpleUseMatchesListRegex(completeExpression, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        //titulo de eleitor
        
    }
}
