using System.Text.RegularExpressions;
using TestRegex.Expressions;

namespace TestRegex.Functions
{
    internal static class SubFunctions
    {

        internal static bool RemoveWritespaceOnBrazilianPhones(string[] input, out string[] result)
        {
            if (input == null)
            {
                result = Array.Empty<string>();
                return false;
            }
            result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = RegexSimplifierFormat.ReplaceRegex(@" ", input[i], string.Empty);
            }

            return true;
        }

        internal static string RemoveWritespacesOnStringResult(string input)
        {
            return RegexSimplifierFormat.ReplaceRegex(Expressions.Expressions.RMWRITESPACESTRING, input, @"\n", RegexOptions.Multiline);
        }

        #region[Auxiliary CPF Functions]

        internal static bool RemoveMaskCPF(string cpf, out string output)
        {
            output = RegexSimplifierFormat.ReplaceRegex(Expressions.Expressions.REMOVEMASKCPF, cpf, "$1$2$3$4");

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
            var regex = new Regex(Expressions.Expressions.RGWITHOUTFINALDIGIT);

            finalDigit = regex.Replace(rgSP, @"$4".ToLower());

            return regex.Replace(rgSP, "$1$2$3");
        }
        #endregion

        #region[Auxiliary CNPJ Functions]

        internal static string GetCNPJNumbersWithoutFinalDigits(string cpnj, out string finalDigits)
        {
            var regex = new Regex(Expressions.Expressions.CNPJWITHOUTFINALDIGITS);

            finalDigits = regex.Replace(cpnj, "$5");

            return regex.Replace(cpnj, "$1$2$3$4");
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

        #region[Auxiliary TitleVote Functions]

        internal static string RemoveWriteSpacesOrDot(string input)
        {
            return RegexSimplifierFormat.ReplaceRegex(@"[ \s.]", input, string.Empty);
        }
        internal static int[] CovertTitleStringInArrayNumbers(string title, out string ufNumbers)
        {
            int[] numbers = new int[12];

            for (int i = 0; i < title.Length; i++)
            {
                numbers[i] = Convert.ToInt32(title[i].ToString());
            }

            ufNumbers = title.Substring(8, 2);

            return numbers;
        }
        internal static string UfOfTitleVote(string ufNumber)
        {
            Dictionary<int, string> UFs = new()
            {
                {01, "SP"},{02, "MG"},{03, "RJ"},{04, "RS"},{05, "BA"},
                {06, "PR"},{07, "CE"},{08, "PE"},{09, "SC"},{10, "GO"},
                {11, "MA"},{12, "PB"},{13, "PA"},{14, "ES"},{15, "PI"},
                {16, "RN"},{17, "AL"},{18, "MT"},{19, "MS"},{20, "DF"},
                {21, "SE"},{22, "AM"},{23, "RO"},{24, "AC"},{25, "AP"},
                {26, "RR"},{27, "TO"},{28, "EXTERIOR"},

            };

            foreach (var uf in UFs)
            {
                if (uf.Key == Convert.ToInt32(ufNumber.ToString()))
                {
                    ufNumber = uf.Value;
                    break;
                }
            }

            return ufNumber;
        }
        internal static int CalculateSumsOfPowers(int[] numbers, int power, int breaker)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (power > breaker) break;

                sum += CalculatePowers(numbers[i], power);
                power++;
            }
            return sum;
        }
        internal static int CalculatePowers(int value, int power)
        {
            return value * power;
        }
        internal static int[] ConvertUfAndFirstDigitVerificationInArrayNumbers(int remainder, string uf)
        {
            int[] array = new int[3];

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 2)
                {
                    array[i] = remainder;
                    break;
                }

                array[i] = Convert.ToInt32(uf[i].ToString());
            }
            return array;
        }

        #endregion

    }
}
