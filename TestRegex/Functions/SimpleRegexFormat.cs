using System.Text.RegularExpressions;

namespace TestRegex.Functions
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

        public static string SimpleUseReplaceRegex(string expression, string input, string groupsPosition)
        {
            var regex = new Regex(expression);

            return regex.Replace(input, groupsPosition);
        }

        public static string SimpleUseReplaceRegex(string expression, string input, string groupsPosition, RegexOptions flag)
        {
            var regex = new Regex(expression, flag);

            return regex.Replace(input, groupsPosition);
        }

        #region[Brazilian Phones]

        public static string FormatBrazilianPhonesWithDDDByAStringInput(string input)
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            string result = regex.Replace(input, subistituition);
            result = SubFunctions.RemoveWritespaceOnBrazilianPhonesString(result);
            return result;
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

        public static string FormatBrazilianPhonesWithoutDDDByAStringInput(string input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2$4-$5";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string result = regex.Replace(input, subistituition);
            result = SubFunctions.RemoveWritespaceOnBrazilianPhonesString(result);

            return result;
        }

        public static string[] FormatBrazilianPhonesWithoutDDDByAListStringInput(string[] input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2 $4-$5";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = regex.Replace(input[i], subistituition);
            }

            return result;
        }

        #endregion

        #region[Brazilian CPF Identity]
        public static string FormatBrazilianIdentityCPFAsString(string input)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1.$2.$3-$4";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string[] FormatBrazilianIdentityCPFAsStringList(string[] input)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1.$2.$3-$4";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = regex.Replace(input[i], subistituition);
            }

            return result;
        }

        #endregion

        #region[Brazilian RG Identity]
        //testar novamente
        public static string FormatBrazilianIdentityRGAsString(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
            string subistituition = @"$1.$2.$3 $4";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string[] FormatBrazilianIdentityRGAsStringList(string[] input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
            string subistituition = @"$1.$2.$3 $4";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = regex.Replace(input[i], subistituition);
            }

            return result;
        }

        #endregion

        #region[Brazilian zipCode(CEP)]

        public static string FormatBrazilianCEPAsString(string input)
        {
            string pattern = @"(\d{5})[-. ]?(\d{3})";
            string subistituition = @"$1-$2";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string[] FormatBrazilianCEPAsStringList(string[] input)
        {
            string pattern = @"(\d{5})[-. ]?(\d{3})";
            string subistituition = @"$1-$2";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = regex.Replace(input[i], subistituition);
            }

            return result;
        }

        #endregion

        #region[Brazilian CNPJ Legal Entity Identification]

        public static string FormatBrazilianCPNJAsString(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})";
            string subistituition = @"$1.$2.$3/$4-$5";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string[] FormatBrazilianCPNJAsStringList(string[] input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})";
            string subistituition = @"$1.$2.$3/$4-$5";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = regex.Replace(input[i], subistituition);
            }

            return result;
        }

        #endregion


    }
}
