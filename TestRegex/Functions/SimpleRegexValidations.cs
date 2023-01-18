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
    }
}
