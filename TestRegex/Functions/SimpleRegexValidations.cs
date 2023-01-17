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


        #region[Auxiliary CPF Validation Functions]

        private static int CalculateMultiplicationByEachNumber(int number, int multiplication)
        {
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
    }
}
