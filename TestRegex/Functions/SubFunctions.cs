﻿using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SubFunctions
    {

        internal static bool RemoveWritespaceOnBrazilianPhones(string[] input, out string[] result)
        {
            if (input == null)
            {
                result = null;
                return false;
            }
            string pattern = @" ";
            result = new string[input.Length];

            var options = RegexOptions.Multiline;
            var rx = new Regex(pattern, options);

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = rx.Replace(input[i], string.Empty);
            }

            return true;
        }



        #region[Auxiliary CPF Functions]

        internal static bool RemoveMaskCPF(string cpf, out string output)
        {
            string pattern = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
            string subistituition = @"$1$2$3$4";

            var regex = new Regex(pattern);

            output = regex.Replace(cpf, subistituition);

            if (output.Length != 11)
            {
                return false;
            }

            return true;

        }

        internal static int CalculateMultiplicationByEachNumber(int number, int multiplication)
        {
            if (number == 0)
            {
                return number;
            }
            return number * multiplication;
        }

        internal static int LoopThroughArrayAndCaptureCalculationValue(int[] arrayOfNumbers, int multiplicationCountdownCounter, int numberBreakLoop)
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

        internal static int CalculateRemainderOfDivision(int baseValue)
        {
            return (baseValue * 10) % 11;
        }

        internal static int[] ConvertCPFStringInArrayOfNumbers(string cpf)
        {
            int[] arrayOfNumbers = new int[11];
            for (int i = 0; i < 11; i++)
            {
                arrayOfNumbers[i] = Convert.ToInt32(cpf[i].ToString());
            }

            return arrayOfNumbers;
        }

        #endregion

        #region[Auxiliary RG Functions]

        internal static int CalculatesMultiplicationOfNumbers(int value, int multiplication)
        {
            if (value == 0)
            {
                return value;
            }

            return value * multiplication;
        }

        internal static int[] ConvertStringInArrayNumber(string rgSP)
        {
            int[] array = new int[8];

            for (int i = 0; i < 8; i++)
            {
                array[i] = Convert.ToInt32(rgSP[i].ToString());
            }

            return array;
        }

        internal static int SumMultipliedNumbers(int[] array, int multiplicationPower)
        {
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                sum += CalculatesMultiplicationOfNumbers(array[i], multiplicationPower);
                multiplicationPower++;
            }

            return sum;
        }

        internal static string TransformRGSPInNumberWithoutFinalDigit(string rgSP, out string finalDigit)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])";
            string subistituition = @"$1$2$3";

            var regex = new Regex(pattern);

            finalDigit = regex.Replace(rgSP, @"$4".ToLower());

            return regex.Replace(rgSP, subistituition);
        }
        #endregion

        #region[Auxiliary CNPJ Functions]

        internal static string GetCNPJNumbersWithoutFinalDigits(string cpnj, out string finalDigits)
        {
            string pattern = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})?";
            string subistitution = @"$1$2$3$4";

            var regex = new Regex(pattern);

            finalDigits = regex.Replace(cpnj, "$5");

            return regex.Replace(cpnj, subistitution);
        }
        internal static List<int> ConvertStringCNPJInArrayNumbers(string cnpj)
        {
            List<int> array = new();

            for (int i = 0; i < cnpj.Length; i++)
            {
                array.Add(int.Parse(cnpj[i].ToString()));
            }

            return array;
        }

        internal static int Sum(List<int> array, int primaryMultiplication, int secondMultiplication, int countPrimaryLoop,
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

        internal static int Multiplication(int value, int multiplicationValue)
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
