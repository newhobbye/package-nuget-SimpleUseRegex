using System.Text.RegularExpressions;
using TestRegex.Expressions;

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
            if (input == null) return new string[input!.Length];

            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETBRAZILIANPHONES, input, RegexOptions.Multiline);

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
            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETEMAILS, input, RegexOptions.IgnoreCase);

            if(result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetCPFBrazilianIdentificationOnStringInput(string input)
        {
            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETCPF, input, RegexOptions.Multiline);
            
            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetRGBrazilianIdentificationOnStringInput(string input)
        {
            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETRG, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;

        }

        public static string[] GetBrazilianCEPOnStringInput(string input)
        {
            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETCEP, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetBrazilianCNPJIdentificationOnStringInput(string input)
        {
            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETCNPJ, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetIpValidFromStringInput(string input)
        {
            string[] result = SimpleUseMatchesListRegex(ExpressionLibrary.GETIPV4, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        //titulo de eleitor
        
    }
}
