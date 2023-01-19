using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexValidations
    {
        public static bool BrazilianCPFValid(string cpf)
        {
            //base das informações de calculo: https://dicasdeprogramacao.com.br/algoritmo-para-validar-cpf/

            string cpfWithoutMask;
            int[] arrayOfNumbers = new int[11];

            if(SubFunctions.RemoveMaskCPF(cpf, out cpfWithoutMask) == false) return false;
           
            try
            {
                arrayOfNumbers = ConvertCPFStringInArrayOfNumbers(cpfWithoutMask);
            }
            catch (Exception)
            {
                return false;
            }

            int primaryValue = LoopThroughArrayAndCaptureCalculationValue(arrayOfNumbers, 10, 9);

            int primaryRemainderValue = CalculateRemainderOfDivision(primaryValue);

            int secondValue = LoopThroughArrayAndCaptureCalculationValue(arrayOfNumbers, 11, 10);

            int secondRemainderValue = CalculateRemainderOfDivision(secondValue);

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

            string rgSpWithoutFinalDigit = TransformRGSPInNumberWithoutFinalDigit(rgSP, out finalDigit);

            try
            {
                numbersOfRG = ConvertStringInArrayNumber(rgSpWithoutFinalDigit);
            }
            catch (Exception)
            {

                return false;
            }

            int sumValues = SumMultipliedNumbers(numbersOfRG, 2);

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
            string cnpjWithoutFinalDigits = GetCNPJNumbersWithoutFinalDigits(cnpj, out finalDigits);
            List<int> numbers = ConvertStringCNPJInArrayNumbers(cnpjWithoutFinalDigits);

            int sumPrimaryDigit = Sum(numbers, 5, 9, 4, 4);

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

            int sumSecondDigit = Sum(numbers, 6, 9, 5, 5);

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

        #region[Auxiliary CPF Validation Functions]

        private static int CalculateMultiplicationByEachNumber(int number, int multiplication)
        {
            if(number == 0)
            {
                return number;
            }
            return number * multiplication;
        }

        private static int LoopThroughArrayAndCaptureCalculationValue(int[] arrayOfNumbers,int multiplicationCountdownCounter, int numberBreakLoop)
        {
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                
                if (i == numberBreakLoop) break;
                sum += CalculateMultiplicationByEachNumber(arrayOfNumbers[i], multiplicationCountdownCounter);
                multiplicationCountdownCounter--;
            }

            return sum;
        }

        private static int CalculateRemainderOfDivision(int baseValue)
        {
            return (baseValue * 10) % 11;
        }

        private static int[] ConvertCPFStringInArrayOfNumbers(string cpf)
        {
            int[] arrayOfNumbers = new int[11];
            for (int i = 0; i < 11; i++)
            {
                arrayOfNumbers[i] = Convert.ToInt32(cpf[i].ToString());
            }

            return arrayOfNumbers;
        }

        #endregion

        #region[Auxiliary RG Validation Functions]

        private static int CalculatesMultiplicationOfNumbers(int value, int multiplication)
        {
            if(value == 0)
            {
                return value;
            }

            return value * multiplication;
        }

        private static int[] ConvertStringInArrayNumber(string rgSP)
        {
            int[] array = new int[8];

            for (int i = 0; i < 8; i++)
            {
                array[i] = Convert.ToInt32(rgSP[i].ToString());
            }

            return array;
        }

        private static int SumMultipliedNumbers(int[] array, int multiplicationPower)
        {
            int sum = 0;    
            for (int i = 0; i < 8; i++)
            {
                sum += CalculatesMultiplicationOfNumbers(array[i], multiplicationPower);
                multiplicationPower++;
            }

            return sum;
        }

        private static string TransformRGSPInNumberWithoutFinalDigit(string rgSP, out string finalDigit)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])";
            string subistituition = @"$1$2$3";

            var regex = new Regex(pattern);

            finalDigit = regex.Replace(rgSP, @"$4".ToLower());

            return regex.Replace(rgSP, subistituition);
        }
        #endregion

        #region[Auxiliary CNPJ Validation Functions]

        private static string GetCNPJNumbersWithoutFinalDigits(string cpnj, out string finalDigits)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})?";
            string subistitution = @"$1$2$3$4";

            var regex = new Regex(pattern);

            finalDigits = regex.Replace(cpnj, "$5");

            return regex.Replace(cpnj, subistitution);
        }
        private static List<int> ConvertStringCNPJInArrayNumbers(string cnpj)
        {
            List<int> array = new List<int>();

            for (int i = 0; i < cnpj.Length; i++)
            {
                array.Add(int.Parse(cnpj[i].ToString()));
            }

            return array;
        }

        private static int Sum(List<int> array, int primaryMultiplication, int secondMultiplication, int countPrimaryLoop, 
            int countSecondLoop)
        {
            int sum = 0;

            for (int i = 0; i < countPrimaryLoop; i++)
            {
                sum += Multiplication(array[i], primaryMultiplication);
                primaryMultiplication--;
            }

            for (int i = countSecondLoop; i < array.Count; i++)
            {
                sum += Multiplication(array[i], secondMultiplication);
                secondMultiplication--;
            }

            return sum;

        }

        private static int Multiplication(int value, int multiplicationValue)
        {
            if (value == 0)
            {
                return value;
            }
            return value * multiplicationValue;
        }

        #endregion
    }
}
