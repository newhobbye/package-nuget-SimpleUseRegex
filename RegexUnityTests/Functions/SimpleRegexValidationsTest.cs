using System.Text.RegularExpressions;
using TestRegex.Functions;
using Xunit;

namespace RegexUnityTests.Functions
{
    public class SimpleRegexValidationsTest
    {
        [Fact(DisplayName = "Função de teste CPF valido.")]
        public void BrazilianCPFValidTest()
        {
            string cpf = "52998224725";
            string cpfFormat = "529.982.247-25";
            
            bool result = RegexSimplifierValidations.BrazilianCPFValid(cpf);

            Assert.True(result);
        }

        [Fact(DisplayName = "Função de teste RG São Paulo valido.")]
        public void BrazilianRGValidSPTest()
        {
            string rg = "394067149";
            string rgFormat = "39.406.714-9";

            bool result = RegexSimplifierValidations.BrazilianRGValidSP(rg);

            Assert.True(result);
        }

        [Fact(DisplayName = "Função de teste CNPJ valido.")]
        public void BrazilianCNPJValidTest()
        {
            string cnpj = "11222333000181";
            string cnpjFormat = "11.222.333/0001-81";

            bool result = RegexSimplifierValidations.BrazilianCNPJValid(cnpj);

            Assert.True(result);
        }

        [Fact(DisplayName = "Função para testar o Regex Match simplificado (Sem passar FLAG)")]
        public void SimpleUseMatchRegexTest()
        {
            string expression = @"(\d{3})";
            string input = "123";

            bool result = RegexSimplifierValidations.MatchRegex(expression, input);

            Assert.True(result);
        }

        [Fact(DisplayName = "Função para testar o Regex Match simplificado (Com FLAG)")]
        public void SimpleUseMatchRegexFlagTest()
        {
            string expression = @"(\d{3})";
            string input = "123";
            var flag = RegexOptions.Multiline;

            bool result = RegexSimplifierValidations.MatchRegex(expression, input, flag);

            Assert.True(result);
        }

        [Fact(DisplayName = "Teste de ip valido")]
        public void IpV4ValidTest()
        {
            string ipValid = "10.0.0.255";
            string ipInvalid = "192.268.0.1";

            bool result = RegexSimplifierValidations.IpV4Valid(ipInvalid);
            Assert.False(result);
        }

        [Fact(DisplayName = "Validador de Titulo de Eleitor")]
        public void VoteTitleValidTest()
        {
            string title = "1023.8501 0671";
            string expectedUf = string.Empty;
            string expected = "PR";

            bool result = RegexSimplifierValidations.VoteTitleValid(title, out expectedUf);
            Assert.Equal(expected, expectedUf); Assert.True(result);
        }

        [Fact(DisplayName = "Validador de senha com letra maiuscula, minuscula, numeros e caracteres especiais")]
        public void PasswordValidTest()
        {
            string password = "VaT@2023";

            bool result = RegexSimplifierValidations.PasswordValid(password);
            Assert.True(result);
        }
    }
}