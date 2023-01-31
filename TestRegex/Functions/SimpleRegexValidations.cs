using System.Text.RegularExpressions;
using TestRegex.Expressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexValidations
    {

        public static bool SimpleUseMatchRegex(string expression, string input) 
        {
            var regex = new Regex(expression);

            return regex.IsMatch(input);
        }

        public static bool SimpleUseMatchRegex(string expression, string input, RegexOptions flag) 
        {
            var regex = new Regex(expression, flag);

            return regex.IsMatch(input);
        }

        public static bool BrazilianCPFValid(string cpf)
        {
            //base das informações de calculo: https://dicasdeprogramacao.com.br/algoritmo-para-validar-cpf/

            string cpfWithoutMask;
            int[] arrayOfNumbers = new int[11];

            if(SubFunctions.RemoveMaskCPF(cpf, out cpfWithoutMask) == false) return false;
           
            try
            {
                arrayOfNumbers = SubFunctions.ConvertCPFStringInArrayOfNumbers(cpfWithoutMask);
            }
            catch (Exception)
            {
                return false;
            }

            int primaryValue = SubFunctions.LoopThroughArrayAndCaptureCalculationValue(arrayOfNumbers, 10, 9);

            int primaryRemainderValue = SubFunctions.CalculateRemainderOfDivision(primaryValue);

            int secondValue = SubFunctions.LoopThroughArrayAndCaptureCalculationValue(arrayOfNumbers, 11, 10);

            int secondRemainderValue = SubFunctions.CalculateRemainderOfDivision(secondValue);

            if (primaryRemainderValue == arrayOfNumbers[9] && secondRemainderValue == arrayOfNumbers[10])
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool BrazilianRGValidSP(string rgSP)
        {
            // referencia de calculo = https://marquesfernandes.com/self/como-saber-e-validar-o-digito-verificador-do-rg-registro-geral/
            int[] numbersOfRG = new int[8];
            string finalDigit = string.Empty;

            string rgSpWithoutFinalDigit = SubFunctions.TransformRGSPInNumberWithoutFinalDigit(rgSP, out finalDigit);

            try
            {
                numbersOfRG = SubFunctions.ConvertStringInArrayNumber(rgSpWithoutFinalDigit);
            }
            catch (Exception)
            {

                return false;
            }

            int sumValues = SubFunctions.SumMultipliedNumbers(numbersOfRG, 2);

            int remainderValue = sumValues % 11;

            int finalValue = 11 - remainderValue;

            

            if(finalValue == int.Parse(finalDigit))
            {
                return true;
            }
            else if (finalValue == 10 && finalDigit == "x")
            {
                return true;
            }
            else if (finalValue == 11 && finalDigit == "0")
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool BrazilianCNPJValid(string cnpj)
        {
            //referencia de calculos =
            //https://www.macoratti.net/alg_cnpj.htm#:~:text=Algoritmo%20para%20valida%C3%A7%C3%A3o%20do%20CNPJ&text=O%20n%C3%BAmero%20que%20comp%C3%B5e%20o,que%20s%C3%A3o%20os%20d%C3%ADgitos%20verificadores.

            string finalDigits;
            string cnpjWithoutFinalDigits = SubFunctions.GetCNPJNumbersWithoutFinalDigits(cnpj, out finalDigits);
            List<int> numbers = SubFunctions.ConvertStringCNPJInArrayNumbers(cnpjWithoutFinalDigits);

            int sumPrimaryDigit = SubFunctions.Sum(numbers, 5, 9, 4, 4);

            int primaryRemainderValue = sumPrimaryDigit % 11;
            int decretedPrimaryFinalDigit = 0;

            if(primaryRemainderValue < 2)
            {
                decretedPrimaryFinalDigit = 0;
            }
            else
            {
                decretedPrimaryFinalDigit = 11 - primaryRemainderValue;
            }

            numbers.Add(decretedPrimaryFinalDigit);

            int sumSecondDigit = SubFunctions.Sum(numbers, 6, 9, 5, 5);

            int secondRemainderValue = sumSecondDigit % 11;
            int decretedSecondFinalDigit = 0;

            if (secondRemainderValue < 2)
            {
                decretedSecondFinalDigit = 0;
            }
            else
            {
                decretedSecondFinalDigit = 11 - secondRemainderValue;
            }

            string digitsCapturedFromCalculations = $"{decretedPrimaryFinalDigit}{decretedSecondFinalDigit}";

            if(digitsCapturedFromCalculations == finalDigits)
            {
                return true;

            }
            else
            {
                return false;
            }
            
        }

        public static bool IpV4Valid(string ip)
        {
            string pattern = @"\b(\d{1,2}|1\d{2}|2[0-4]\d|25[0-5])\b";
            string completeExpression = @$"{pattern}\.{pattern}\.{pattern}\.{pattern}";

            return SimpleUseMatchRegex(completeExpression, ip);
        }

        public static bool VoteTitleValid(string title, out string uf)
        {
            uf = string.Empty;

            if (string.IsNullOrEmpty(title)) return false;

            title = SubFunctions.RemoveWriteSpacesOrDot(title);

            int[] numbers = SubFunctions.CovertTitleStringInArrayNumbers(title, out uf);
            int sumOfPrimaryValues = SubFunctions.CalculateSumsOfPowers(numbers, 2, 9);
            int primaryRemainder = sumOfPrimaryValues % 11;

            if (primaryRemainder == 10)
            {
                primaryRemainder = 0;
            }

            int[] ufAndDVNumbers =
                SubFunctions.ConvertUfAndFirstDigitVerificationInArrayNumbers(primaryRemainder, uf);
            int sumOfSecondaryValues = SubFunctions.CalculateSumsOfPowers(ufAndDVNumbers, 7, 9);
            int secondaryRemainder = sumOfSecondaryValues % 11;

            if (secondaryRemainder == 10)
            {
                secondaryRemainder = 0;
            }

            uf = SubFunctions.UfOfTitleVote(uf);

            string VerificationDigits = string.Concat(primaryRemainder.ToString(), secondaryRemainder.ToString());

            if(VerificationDigits == title.Substring(10, 2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool PasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            bool result = SimpleUseMatchRegex(ExpressionLibrary.PASSWORDVALID, password);

            if (result == true) return true;
            else return false;  
        }

    }
}
