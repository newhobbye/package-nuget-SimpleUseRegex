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

        #region[Brazilian Phones]

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

        public static string FormatBrazilianPhonesWithoutDDDByAStringInput(string input)
        {
            string pattern = @"((9)?( )?)(\d{4,5})-?(\d{4})";
            string subistituition = @"$2 $4-$5";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
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

        //rg
        #region[Brazilian RG Identity]

        public static string FormatBrazilianIdentityRGAsString(string input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?(\d)?";
            string subistituition = @"$1.$2.$3 $4";

            var regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.Replace(input, subistituition);
        }

        public static string[] FormatBrazilianIdentityRGAsStringList(string[] input)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?(\d)?";
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

        //cep

        //cnpj

    }
}
