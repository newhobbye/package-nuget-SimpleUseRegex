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

            string result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDByAStringInput(formatBrazilianPhones);

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

            string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDByAListStringInput(formatBrazilianPhonesList);

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

            string result = SimpleRegexFormat.FormatBrazilianPhonesWithoutDDDByAStringInput(formatBrazilianPhonesWithoutDDD);

            Assert.Equal(expected, result);

            //parei no formatador de array
        }

        #endregion
    }
}
