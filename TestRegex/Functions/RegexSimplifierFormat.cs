using System.Text.RegularExpressions;
using TestRegex.Expressions;

namespace TestRegex.Functions
{
    public static class RegexSimplifierFormat
    { 

        public static string ReplaceRegex(string expression, string input, string replace)
        {
            var regex = new Regex(expression);

            return regex.Replace(input, replace);
        }

        public static string ReplaceRegex(string expression, string input, string replace, RegexOptions flag)
        {
            var regex = new Regex(expression, flag);

            return regex.Replace(input, replace);
        }

        public static string RemoveTagsInAnHTMLBody(string input)
        {
            return ReplaceRegex(Expressions.Expressions.HTMLTAGS, input, "$3", RegexOptions.Multiline);
        }

        #region[Brazilian Phones]

        public static string FormatBrazilianPhonesWithDDD(string input)
        {
            string result = ReplaceRegex(Expressions.Expressions.BRPHONESWITHDDD, input, @"($2) $4$5-$6", RegexOptions.Multiline);

            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianPhonesWithDDDReturnArray(string input)
        {
            string[] matches = RegexSimplifierMatchList.MatchesListRegex(Expressions.Expressions.BRPHONESWITHDDD, input, RegexOptions.Multiline);
            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.BRPHONESWITHDDD, matches[i].ToString(), @"($2) $4$5-$6", RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianPhonesWithDDD(string[] input) 
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.BRPHONESWITHDDD, input[i], @"($2) $4$5-$6", RegexOptions.Multiline);
            }

            return result;
        }

        public static string FormatBrazilianPhonesWithoutDDD(string input)
        {
            string result = ReplaceRegex(Expressions.Expressions.BRPHONESWITHOUTDDD, input, @"$2$4-$5", RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianPhonesWithoutDDDReturnArray(string input)
        {
            string[] matches = RegexSimplifierMatchList.MatchesListRegex(Expressions.Expressions.BRPHONESWITHOUTDDD, input, RegexOptions.Multiline);
            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.BRPHONESWITHOUTDDD, matches[i].ToString(), @"$2$4-$5", RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianPhonesWithoutDDD(string[] input)
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.BRPHONESWITHOUTDDD, input[i], @"$2$4-$5", RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian CPF Identity]
        public static string FormatBrazilianIdentityCPF(string input)
        {
            string result = ReplaceRegex(Expressions.Expressions.FORMATCPF, input, @"$1.$2.$3-$4", RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianIdentityCPFReturnArray(string input)
        {
            string[] matches = RegexSimplifierMatchList.MatchesListRegex(Expressions.Expressions.FORMATCPF, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATCPF, matches[i], @"$1.$2.$3-$4", RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianIdentityCPF(string[] input)
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATCPF, input[i], @"$1.$2.$3-$4", RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian RG Identity]
        public static string FormatBrazilianIdentityRG(string input)
        {
            string result = ReplaceRegex(Expressions.Expressions.FORMATRG, input, @"$1.$2.$3 $4", RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianIdentityRGReturnArray(string input)
        {
            string[] matches = RegexSimplifierMatchList.MatchesListRegex(Expressions.Expressions.FORMATRG, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATRG, matches[i], @"$1.$2.$3 $4", RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianIdentityRG(string[] input)
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATRG, input[i], @"$1.$2.$3 $4", RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian zipCode(CEP)]

        public static string FormatBrazilianCEP(string input)
        {
            string result = ReplaceRegex(Expressions.Expressions.FORMATCEP, input, @"$1-$2", RegexOptions.Multiline);

            result = SubFunctions.RemoveWritespacesOnStringResult(result);

            return result;
        }

        public static string[] FormatBrazilianCEPReturnArray(string input)
        {
            string[] matches = RegexSimplifierMatchList.MatchesListRegex(Expressions.Expressions.FORMATCEP, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATCEP, matches[i], @"$1-$2", RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianCEP(string[] input)
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATCEP, input[i], @"$1-$2", RegexOptions.Multiline);
            }

            return result;
        }

        #endregion

        #region[Brazilian CNPJ Legal Entity Identification]

        public static string FormatBrazilianCPNJ(string input)
        {
            string result = ReplaceRegex(Expressions.Expressions.FORMATCNPJ, input, @"$1.$2.$3/$4-$5", RegexOptions.Multiline);
            result = SubFunctions.RemoveWritespacesOnStringResult(result);
            return result;
        }

        public static string[] FormatBrazilianCPNJReturnArray(string input)
        {
            string[] matches = RegexSimplifierMatchList.MatchesListRegex(Expressions.Expressions.FORMATCNPJ, input, RegexOptions.Multiline);

            string[] result = new string[matches.Length];

            for (int i = 0; i < matches.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATCNPJ, matches[i], @"$1.$2.$3/$4-$5", RegexOptions.Multiline);
            }

            return result;
        }

        public static string[] FormatBrazilianCPNJ(string[] input)
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReplaceRegex(Expressions.Expressions.FORMATCNPJ, input[i], @"$1.$2.$3/$4-$5", RegexOptions.Multiline);
            }

            return result;
        }

        #endregion


    }
}
