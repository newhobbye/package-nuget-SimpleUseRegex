using System.Text.RegularExpressions;
using TestRegex.Functions;
using Xunit;

namespace RegexUnityTests.Functions
{
    public class SimpleRegexMatchListTest
    {
        [Fact(DisplayName = "Forma facilitada de usar o Regex.Matches")]
        public void SimpleUseMatchesListRegexTest()
        {
            string emails = @"Os e-mails dos convidados são:

            - usdfuyasdiofy iisdfoi sidsaduio@dofis.dfd fulano@cod3r.com.br
            -xico@gmail.com
            - rmonteiro@brasilcash.com.br
            -prefeitura123@prefeitura.org.br
            -   mart4463@outlook.com
            ";

            string expression = @"((\w+@)(\w+)\.(\w{3})?(\.\w{2})?)";
            var flag = RegexOptions.Multiline;
            string[] expected =
            {
                "sidsaduio@dofis.dfd",
                "fulano@cod3r.com.br",
                "xico@gmail.com",
                "rmonteiro@brasilcash.com.br",
                "prefeitura123@prefeitura.org.br",
                "mart4463@outlook.com"
            };

            string[] result = SimpleRegexMatchList.SimpleUseMatchesListRegex(expression, emails, flag);
            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Pegar telefones em uma string")]
        public void PickUpBrazilianPhonesOnAStringInputTest()
        {
            string phonesBr = @"Lista telefônica:
                -sduiasdfu rgvfiogri 2344231 44446-454 (11) 98756-1212
                -98765-4321 uidosfh duhduigohdfuioHE 
                -1125344552 11 9 8324-2011
                - (11) 9 5510-8105
                -11 94444-3333
                - 1193655-4141
                -(11)96577-1020

                (25)452566744";

            string[] expected =
            {
                "(11)98756-1212",
                "98765-4321",
                "1125344552",
                "1198324-2011",
                "(11)95510-8105",
                "1194444-3333",
                "1193655-4141",
                "(11)96577-1020",
                "(25)452566744"
            };

            string[] result = SimpleRegexMatchList.PickUpBrazilianPhonesOnAStringInput(phonesBr);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Pegar emails em uma string")]
        public void GetEmailsInStringInputTest()
        {
            string emails = @"Os e-mails dos convidados são:

                - usdfuyasdiofy iisdfoi sidsaduio@dofis.dfd fulano@cod3r.com.br
                -xico@gmail.com
                - rmonteiro@brasilcash.com.br
                -prefeitura123@prefeitura.org.br
                -   mart4463@outlook.com
                ";

            string[] expected =
            {
                "sidsaduio@dofis.dfd",
                "fulano@cod3r.com.br",
                "xico@gmail.com",
                "rmonteiro@brasilcash.com.br",
                "prefeitura123@prefeitura.org.br",
                "mart4463@outlook.com"
            };

            string[] result = SimpleRegexMatchList.GetEmailsInStringInput(emails);
            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Pegar CPFs em uma string")]
        public void GetCPFBrazilianIdentificationOnStringInputTest()
        {
            string CPFs = @"CPF dos aprovados:
                - asudiodu 600.567.890-12 asidosd
                - 765.998.345-23sdadiopo
                - xzcsffgcvxzfc159.753.789-12
                - 466.697.090-65 fuasdiosdfd";

            string[] expected =
            {
                "600.567.890-12",
                "765.998.345-23",
                "159.753.789-12",
                "466.697.090-65"
            };

            string[] result = SimpleRegexMatchList.GetCPFBrazilianIdentificationOnStringInput(CPFs);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Pegar RGs em uma string")]
        public void GetRGBrazilianIdentificationOnStringInputTest()
        {
            string RGs = @"CPF dos aprovados:
                - asudiodu 48.567.890-3 asidosd
                - 23.058.669 sdadiopo
                - xzcsffgcvxzfc15.444.333 5
                - 21.878.6634 fuasdiosdfd


                      33.333.3334";

            string[] expected =
            {
                "48.567.890-3",
                "23.058.669",
                "15.444.333 5",
                "21.878.6634",
                "33.333.3334"
            };

            string[] result = SimpleRegexMatchList.GetRGBrazilianIdentificationOnStringInput(RGs);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Pegar CEPs em uma string")]
        public void GetBrazilianCEPOnStringInputTest()
        {
            //OBS de pattern
            string CEPs = @"mnjiovdn dsfnjoifgh ?: dffgujwe
                g

                rhg 06317-050 wejhuiorguob 01234-567 123445567
                gfh 44455-22233 254455555-444 fgdeyhrryhh77777-888dfgsrth
                ";

            string[] expected =
            {
                "06317-050",
                "01234-567",
                
            };

            string[] result = SimpleRegexMatchList.GetBrazilianCEPOnStringInput(CEPs);
            Assert.Equal (expected, result);
        }

        [Fact(DisplayName = "Pegar CNPJs em uma string")]
        public void GetBrazilianCNPJIdentificationOnStringInputTest()
        {
            string CNPJs = @"mnjiovdn dsfnjoifgh ?: dffgujwe
                g

                rhg 30.507.541/0001-71 wejhuiorguob 00.000.000/0001-01 123445567
                gfh 30.507.541/0001-7133 254430.507.541/0001-71 fgdeyhrryhh30.507.541/0001-71dfgsrth
                ";

            string[] expected =
            {
                "30.507.541/0001-71",
                "00.000.000/0001-01",
                "30.507.541/0001-71",
                "30.507.541/0001-71",
                "30.507.541/0001-71"
            };

            string[] result = SimpleRegexMatchList.GetBrazilianCNPJIdentificationOnStringInput(CNPJs);
            Assert.Equal (expected, result);
        }

        [Fact(DisplayName = "Capturar IP's validos em uma string")]
        public void GetIpValidFromStringInput()
        {
            string input = @"invalidos:

                    192.268.0.1
                    1.333.1.1
                    192.168.0.256
                    256.256.256.256

                    validos:
                    192.168.0.1
                    127.0.0.1
                    10.0.0.255
                    10.11.12.0
                    255.255.255.255
                    0.0.0.0
                    ";

            string[] expected =
            {
                "192.168.0.1",
                "127.0.0.1",
                "10.0.0.255",
                "10.11.12.0",
                "255.255.255.255",
                "0.0.0.0"
            };

            string[] result = SimpleRegexMatchList.GetIpValidFromStringInput(input);
            Assert.Equal (expected, result);
        }

    }
}
