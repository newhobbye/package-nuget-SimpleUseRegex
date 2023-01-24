using System.Text.RegularExpressions;
using TestRegex.Functions;
using Xunit;

namespace RegexUnityTests.Functions
{
    public class SimpleRegexFormatTest
    {
        [Fact(DisplayName = "Remove tags html de uma string")]
        public void RemoveTagsInAnHTMLBodyTest()
        {
            string tags = @"<div id=""snbc"">

            Testando formatação e codigo do regex</div>";

            string expected = "Testando formatação e codigo do regex";

            string result = SimpleRegexFormat.RemoveTagsInAnHTMLBody(tags);

            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Forma simplificada de usar o Replace do Regex")]
        public void SimpleUseReplaceRegexTest()
        {
            string expression = @"(\d{3}) (\d{2})";
            string input = "555 44";
            string replace = "$2 $1";

            string expected = "44 555";
            string result = SimpleRegexFormat.SimpleUseReplaceRegex(expression, input, replace);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Forma simplificada de usar o Replace do Regex passando flag")]
        public void SimpleUseReplaceRegexFlagTest()
        {
            string expression = @"(\d{3}) (\d{2})";
            string input = "555 44";
            string replace = "$2 $1";

            string expected = "44 555";
            string result = SimpleRegexFormat.SimpleUseReplaceRegex(expression, input, replace, RegexOptions.Multiline);
            Assert.Equal(expected, result);
        }

        #region[Telefones com DDD]

        [Fact(DisplayName = "Formatador de telefones brasileiros com DDD")]
        public void FormatBrazilianPhonesWithDDDByAStringInputTest()
        {
            string formatBrazilianPhones = @"
                    1125344552
                    11 9 8324-2011
                    1193655-4141
                    (11)922554433";

            string expected = @"\n(11) 2534-4552\n(11) 98324-2011\n(11) 93655-4141\n(11) 92255-4433";

            string result = SimpleRegexFormat.FormatBrazilianPhonesWithDDD(formatBrazilianPhones);

            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Formatador de telefones com DDD. Entrada: string, saida: string[]")]
        public void FormatBrazilianPhonesWithDDDReturnArrayTest()
        {
            string formatBrazilianPhones = @"
                    1125344552
                    11 9 8324-2011
                    1193655-4141
                    (11)922554433";

            string[] expected =
            {
                    "(11) 2534-4552",
                    "(11) 98324-2011",
                    "(11) 93655-4141",
                    "(11) 92255-4433"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDReturnArray(formatBrazilianPhones);
            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Formatador de telefones brasileiros com DDD com entrada de array")]
        public void FormatBrazilianPhonesWithDDDByAListStringInputTest()
        {
            string[] formatBrazilianPhonesList =
            {
                    "1125344552",
                    "11 9 8324-2011",
                    "1193655-4141",
                    "(11)922554433"
            };

            string[] expected =
            {
                    "(11) 2534-4552",
                    "(11) 98324-2011",
                    "(11) 93655-4141",
                    "(11) 92255-4433"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithDDD(formatBrazilianPhonesList);

            Assert.Equal(expected, result);

        }

        #endregion

        #region[Telefones sem DDD]

        [Fact(DisplayName = "Formatador de telefones brasileiros sem DDD")]
        public void FormatBrazilianPhonesWithoutDDDByAStringInputTest()
        {
            string formatBrazilianPhonesWithoutDDD = @"

                    98727-8321
                    9 9342-6623
                    922443322
                    9 22443322
                    5510-8105
                    55108105";

            string expected = @"\n98727-8321\n99342-6623\n92244-3322\n92244-3322\n5510-8105\n5510-8105";

            string result = SimpleRegexFormat.FormatBrazilianPhonesWithoutDDD(formatBrazilianPhonesWithoutDDD);

            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Formatador de telefones sem DDD. Entrada: string, saida: string[]")]
        public void FormatBrazilianPhonesWithoutDDDReturnArrayTest()
        {
            string formatBrazilianPhonesWithoutDDD = @"

                    98727-8321
                    9 9342-6623
                    922443322
                    9 22443322
                    5510-8105
                    55108105";

            string[] expected =
            {
                "98727-8321",
                "99342-6623",
                "92244-3322",
                "92244-3322",
                "5510-8105",
                "5510-8105"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithoutDDDReturnArray(formatBrazilianPhonesWithoutDDD);
            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Formatador de telefones brasileiros sem DDD com entrada de array")]
        public void FormatBrazilianPhonesWithoutDDDByAListStringInputTest()
        {
            string[] formatBrazilianPhonesListWithoutDDD =
            {
                "98727-8321",
                "9 9342-6623",
                "922443322",
                "9 22443322",
                "5510-8105",
                "55108105"
            };

            string[] expected =
            {
                "98727-8321",
                "99342-6623",
                "92244-3322",
                "92244-3322",
                "5510-8105",
                "5510-8105"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithoutDDD(formatBrazilianPhonesListWithoutDDD);

            Assert.Equal(expected, result);

        }

        #endregion

        #region[CPF]

        [Fact(DisplayName = "Formatador de cpf de uma string")]
        public void FormatBrazilianIdentityCPFAsStringTest()
        {
            string cpfsFormat = @"
                444697018-66
                111.222333 66
                111.222.333 66
                466.555.22244
                111222.333-00";

            string expected = @"\n444.697.018-66\n111.222.333-66\n111.222.333-66\n466.555.222-44\n111.222.333-00";

            string result = SimpleRegexFormat.FormatBrazilianIdentityCPF(cpfsFormat);

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de cpf. entrada: string, saida: string[]")]
        public void FormatBrazilianIdentityCPFReturnArrayTest()
        {
            string cpfsFormat = @"
                444697018-66
                111.222333 66
                111.222.333 66
                466.555.22244
                111222.333-00";

            string[] expected =
            {
                "444.697.018-66",
                "111.222.333-66",
                "111.222.333-66",
                "466.555.222-44",
                "111.222.333-00"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianIdentityCPFReturnArray(cpfsFormat);

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de cpf de um array de strings")]
        public void FormatBrazilianIdentityCPFAsStringListTest()
        {
            string[] cpfsFormatList =
            {
                "444697018-66",
                "111.222333 66",
                "111.222.333 66",
                "466.555.22244",
                "111222.333-00"
            };

            string[] expected =
            {
                "444.697.018-66",
                "111.222.333-66",
                "111.222.333-66",
                "466.555.222-44",
                "111.222.333-00"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianIdentityCPF(cpfsFormatList);

            Assert.Equal(expected, result);
        }


        #endregion

        #region[RG]

        [Fact(DisplayName = "Formatador de rg de uma string")]
        public void FormatBrazilianIdentityRGAsStringTest()
        {
            string rgsFormat = @"
            44697018-6
            11.222333 6
            11.222.333 6
            46.555.2224
            11222.333-0
            11.222.333
            11222333";

            string expected = @"\n44.697.018 6\n11.222.333 6\n11.222.333 6\n46.555.222 4\n11.222.333 0\n11.222.333\n11.222.333 ";

            string result = SimpleRegexFormat.FormatBrazilianIdentityRG(rgsFormat);
            Assert.Equal(expected, result); 
        }

        [Fact(DisplayName = "Formatador de rg. entrada: string, saida: string[]")]
        public void FormatBrazilianIdentityRGReturnArrayTest()
        {
            string rgsFormat = @"
                44697018-6
                11.222333 6
                11.222.333 6
                46.555.2224
                11222.333-0
                11.222.333
                11222333";

            string[] expected =
            {
                "44.697.018 6",
                "11.222.333 6",
                "11.222.333 6",
                "46.555.222 4",
                "11.222.333 0",
                "11.222.333 ",
                "11.222.333 "

            };

            string[] result = SimpleRegexFormat.FormatBrazilianIdentityRGReturnArray(rgsFormat);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de rg de um array de strings")]
        public void FormatBrazilianIdentityRGAsStringListTest()
        {
            string[] rgssFormatList =
            {
                "44697018-6",
                "11.222333 6",
                "11.222.333 6",
                "46.555.2224",
                "11222.333-0",
                "11222333",

            };

            string[] expected =
            {
                "44.697.018 6",
                "11.222.333 6",
                "11.222.333 6",
                "46.555.222 4",
                "11.222.333 0",
                "11.222.333 ",

            };

            string[] result = SimpleRegexFormat.FormatBrazilianIdentityRG(rgssFormatList);
            Assert.Equal(expected, result);
        }

        #endregion

        #region[CEP]

        [Fact(DisplayName = "Formatador de CEP de uma string")]
        public void FormatBrazilianCEPAsStringTest()
        {
            string cepFormat = @"
                00111-150
                06317050
                06317 050
                06317.050";

            string expected = @"\n00111-150\n06317-050\n06317-050\n06317-050";

            string result = SimpleRegexFormat.FormatBrazilianCEP(cepFormat);

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de CEP. entrada: string, saida: string[]")]
        public void FormatBrazilianCEPReturnArrayTest()
        {
            string cepFormat = @"
                00111-150
                06317050
                06317 050
                06317.050";

            string[] expected =
            {
                "00111-150",
                "06317-050",
                "06317-050",
                "06317-050"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianCEPReturnArray(cepFormat);

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de CEP de um array de strings")]
        public void FormatBrazilianCEPAsStringListTest()
        {
            string[] cepFormatList =
            {
                "00111-150",
                "06317050",
                "06317 050",
                "06317.050"
            };

            string[] expected =
            {
                "00111-150",
                "06317-050",
                "06317-050",
                "06317-050"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianCEP(cepFormatList);

            Assert.Equal(expected, result);
        }

        #endregion

        #region[CNPJ]

        [Fact(DisplayName = "Formatador de cnpj de uma string")]
        public void FormatBrazilianCPNJAsStringTest()
        {
            string cnpjFormat = @"
            82931873000182
            62.447.057/0001-90
            62447057/0001-90
            624470570001-90
            62.447.0570001-90
            62.447.057/0001 90
            62.447.0570001 90";

            string expected = @"\n82.931.873/0001-82\n62.447.057/0001-90\n62.447.057/0001-90\n62.447.057/0001-90\n62.447.057/0001-90\n62.447.057/0001-90\n62.447.057/0001-90";

            string result = SimpleRegexFormat.FormatBrazilianCPNJ(cnpjFormat);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de cnpj. entrada: string, saida: string[]")]
        public void FormatBrazilianCPNJReturnArrayTest()
        {
            string cnpjFormat = @"
                82931873000182
                62.447.057/0001-90
                62447057/0001-90
                624470570001-90
                62.447.0570001-90
                62.447.057/0001 90
                62.447.0570001 90";

            string[] expected =
            {
                "82.931.873/0001-82",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianCPNJReturnArray(cnpjFormat);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Formatador de cnpj de um array de strings")]
        public void FormatBrazilianCPNJAsStringListTest()
        {
            string[] cnpjFormatList =
            {
                "82931873000182",
                "62.447.057/0001-90",
                "62447057/0001-90",
                "624470570001-90",
                "62.447.0570001-90",
                "62.447.057/0001 90",
                "62.447.0570001 90"
            };

            string[] expected =
            {
                "82.931.873/0001-82",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90",
                "62.447.057/0001-90"
            };

            string[] result = SimpleRegexFormat.FormatBrazilianCPNJ(cnpjFormatList);
            Assert.Equal(expected, result);
        }

        #endregion
    }
}
