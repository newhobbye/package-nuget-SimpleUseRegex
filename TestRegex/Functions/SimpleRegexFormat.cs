using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexFormat
    { //posteriormente, colocar metodos com entrada de string e retorno de string[]

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

        public static string FormatBrazilianPhonesWithDDDByAStringInput(string input)
        {
            string pattern = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
            string subistituition = @"($2) $4$5-$6";

            string result = SimpleUseReplaceRegex(pattern, input, subistituition, RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
        }

        public static string[] FormatBrazilianPhonesWithDDDByAListStringInput(string[] input) //parei aqui. Criar metodo 
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
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianPhonesWithoutDDDByAListStringInput(string[] input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2$4-$5";

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
            string result = regex.Replace(input, subistituition);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
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
        public static string FormatBrazilianIdentityRGAsString(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
            string subistituition = @"$1.$2.$3 $4";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string result = regex.Replace(input, subistituition);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
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
            string result = regex.Replace(input, subistituition);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
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
            string result = regex.Replace(input, subistituition);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
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
