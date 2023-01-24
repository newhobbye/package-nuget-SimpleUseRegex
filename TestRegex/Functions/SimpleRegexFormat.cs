using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexFormat
    { 

        public static string RemoveTagsInAnHTMLBody(string input)
        {
            string pattern = @"(<\w+.+?>)(\s+)?(.+?)(\s+)?(<\/\w+>)";
            string subistituition = @"$3";
            return SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
        }

        public static string SimpleUseReplaceRegex(string expression, string input, string replace)
        {
            var regex = new Regex(expression);

            return regex.Replace(input, replace);
        }

        public static string SimpleUseReplaceRegex(string expression, string input, string replace, RegexOptions flag)
        {
            var regex = new Regex(expression, flag);

            return regex.Replace(input, replace);
        }

        #region[Brazilian Phones]

        public static string FormatBrazilianPhonesWithDDD(string input)
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
        }

        public static string[] FormatBrazilianPhonesWithDDDReturnArray(string input)
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";
            string[] matches = SimpleRegexMatchList.SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);
            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, matches[i].ToString(), subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianPhonesWithDDD(string[] input) 
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, input[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string FormatBrazilianPhonesWithoutDDD(string input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2$4-$5";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianPhonesWithoutDDDReturnArray(string input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2$4-$5";
            string[] matches = SimpleRegexMatchList.SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);
            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, matches[i].ToString(), subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianPhonesWithoutDDD(string[] input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2$4-$5";

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, input[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian CPF Identity]
        public static string FormatBrazilianIdentityCPF(string input)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1.$2.$3-$4";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianIdentityCPFReturnArray(string input)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1.$2.$3-$4";
            string[] matches = SimpleRegexMatchList.SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, matches[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianIdentityCPF(string[] input)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1.$2.$3-$4";

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, input[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian RG Identity]
        public static string FormatBrazilianIdentityRG(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
            string subistituition = @"$1.$2.$3 $4";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianIdentityRGReturnArray(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
            string subistituition = @"$1.$2.$3 $4";
            string[] matches = SimpleRegexMatchList.SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, matches[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianIdentityRG(string[] input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
            string subistituition = @"$1.$2.$3 $4";

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, input[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian zipCode(CEP)]

        public static string FormatBrazilianCEP(string input)
        {
            string pattern = @"(\d{5})[-. ]?(\d{3})";
            string subistituition = @"$1-$2";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
        }

        public static string[] FormatBrazilianCEPReturnArray(string input)
        {
            string pattern = @"(\d{5})[-. ]?(\d{3})";
            string subistituition = @"$1-$2";
            string[] matches = SimpleRegexMatchList.SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, matches[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianCEP(string[] input)
        {
            string pattern = @"(\d{5})[-. ]?(\d{3})";
            string subistituition = @"$1-$2";

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, input[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian CNPJ Legal Entity Identification]

        public static string FormatBrazilianCPNJ(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})";
            string subistituition = @"$1.$2.$3/$4-$5";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
        }

        public static string[] FormatBrazilianCPNJReturnArray(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})";
            string subistituition = @"$1.$2.$3/$4-$5";
            string[] matches = SimpleRegexMatchList.SimpleUseMatchesListRegex(pattern, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, matches[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianCPNJ(string[] input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})";
            string subistituition = @"$1.$2.$3/$4-$5";

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = SimpleUseReplaceRegex(pattern, input[i], subistituition, RegexOptions.Multiline);
            }

            return result;
        }

        #endregion


    }
}
