using System.Text.RegularExpressions;

namespace TestRegex.Functions
{
    public static class SimpleRegexMatchList
    {

        public static string[] SimpleUseMatchesListRegex(string expression, string input, RegexOptions flag)
        {
            var regex = new Regex(expression, flag);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;
        }

        public static string[] PickUpBrazilianPhonesOnAStringInput(string input)
        {
            if (input == null) return new string[input.Length];

            string pattern = @"((\(?\d{2}\)?)\s?)?(9{1})?\s?((\d{4,5})-?\d{4})";
            var rx = new Regex(pattern, RegexOptions.Multiline);
            var matches = rx.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            if (SubFunctions.RemoveWritespaceOnBrazilianPhones(result, out result))
            {
                return result;
            }
            else
            {
                result = new string[0];
                return result;
            }

        }

        public static string[] GetEmailsInStringInput(string input)
        {

            string pattern = @"((\w+@)(\w+)\.(\w{3})?(\.\w{2})?)";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;
        }

        public static string[] GetCPFBrazilianIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{3}\.\d{3}.\d{3}-\d{2})";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;
        }

        public static string[] GetRGBrazilianIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{2})\.(\d{3})\.(\d{3})(\s?-?\d{1})?";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;

        }

        public static string[] GetBrazilianCEPOnStringInput(string input)
        {
            string pattern = @"(\d{5}-\d{3})";
            var regex = new Regex(pattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;

        }

        public static string[] GetBrazilianCNPJIdentificationOnStringInput(string input)
        {
            string pattern = @"(\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})";
            var regex = new Regex(pattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].ToString();
            }

            return result;

        }

        //tags html
        //vai dar pau por causa do conceito de caixas. EX:

        //<div id = "snbc" >
        //    < div jsname="sM5MNb" aria-live="polite" class="SaJ9Qe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="assertive" class="tYAdEe"></div>
        //    <div jsname = "sM5MNb" aria-live="polite" class="tYAdEe" style="z-index:2000"></div>
        //    <div jsname = "sM5MNb" aria-live="polite" class="tYAdEe" style="z-index:2000"></div>
        //</div>
        
    }
}
