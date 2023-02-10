using System.Text.RegularExpressions;
using TestRegex.Expressions;

namespace TestRegex.Functions
{
    public static class RegexSimplifierMatchList
    {

        public static string[] MatchesListRegex(string expression, string input, RegexOptions flag)
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

            string[] result = MatchesListRegex(Expressions.Expressions.GETBRAZILIANPHONES, input, RegexOptions.Multiline);

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
            string[] result = MatchesListRegex(Expressions.Expressions.GETEMAILS, input, RegexOptions.IgnoreCase);

            if(result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetCPFBrazilianIdentificationOnStringInput(string input)
        {
            string[] result = MatchesListRegex(Expressions.Expressions.GETCPF, input, RegexOptions.Multiline);
            
            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetRGBrazilianIdentificationOnStringInput(string input)
        {
            string[] result = MatchesListRegex(Expressions.Expressions.GETRG, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;

        }

        public static string[] GetBrazilianCEPOnStringInput(string input)
        {
            string[] result = MatchesListRegex(Expressions.Expressions.GETCEP, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetBrazilianCNPJIdentificationOnStringInput(string input)
        {
            string[] result = MatchesListRegex(Expressions.Expressions.GETCNPJ, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        public static string[] GetIpValidFromStringInput(string input)
        {
            string[] result = MatchesListRegex(Expressions.Expressions.GETIPV4, input, RegexOptions.Multiline);

            if (result == null) return Array.Empty<string>();

            return result;
        }

        //titulo de eleitor
        
    }
}
