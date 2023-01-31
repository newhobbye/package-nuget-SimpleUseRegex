namespace TestRegex.Expressions
{
    internal static class ExpressionLibrary
    {
        #region[Validations]
        public readonly static string PASSWORDVALID = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%!^&*]).{6,20}$";
        #endregion

        #region[MatchList]
        public readonly static string GETBRAZILIANPHONES = @"((\(?\d{2}\)?)\s?)?(9{1})?\s?((\d{4,5})-?\d{4})";
        public readonly static string GETEMAILS = @"((\w+@)(\w+)\.(\w{3})?(\.\w{2})?)";
        public readonly static string GETCPF = @"(\d{3}\.\d{3}.\d{3}-\d{2})";
        public readonly static string GETRG = @"(\d{2})\.(\d{3})\.(\d{3})(\s?-?\d{1})?";
        public readonly static string GETCEP = @"\b(\d{5}-\d{3})\b"; //pattern que só pega se for separado
        public readonly static string GETCNPJ = @"(\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})";
        private readonly static string _IPV4GROUP = @"\b(\d{1,2}|1\d{2}|2[0-4]\d|25[0-5])\b";
        public static readonly string GETIPV4 = @$"{_IPV4GROUP}\.{_IPV4GROUP}\.{_IPV4GROUP}\.{_IPV4GROUP}";
        #endregion

        #region[Format]
        public static readonly string HTMLTAGS = @"(<\w+.+?>)(\s+)?(.+?)(\s+)?(<\/\w+>)";
        public static readonly string BRPHONESWITHDDD = @"(\()?(\d{2})(\))?\s?(\d)?\s?(\d{4,5})-?(\d{4})";
        public static readonly string BRPHONESWITHOUTDDD = @"((9)?( )?)(\d{4,5})-?(\d{4})";
        public static readonly string FORMATCPF = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
        public static readonly string FORMATRG = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])?";
        public static readonly string FORMATCEP = @"(\d{5})[-. ]?(\d{3})";
        public static readonly string FORMATCNPJ = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})";
        #endregion

        #region[SubFunctions]
        public static readonly string RMWRITESPACESTRING = @"([\s ]{10,})";
        public static readonly string REMOVEMASKCPF = @"(\d{3})\.?(\d{3})\.?(\d{3})[ -]?(\d{2})";
        public static readonly string RGWITHOUTFINALDIGIT = @"(\d{2})\.?(\d{3})\.?(\d{3})[ -]?([\dxX])";
        public static readonly string CNPJWITHOUTFINALDIGITS = @"(\d{2})\.?(\d{3})\.?(\d{3})\/?(\d{4})[-. ]?(\d{2})?";
        #endregion
    }
}
