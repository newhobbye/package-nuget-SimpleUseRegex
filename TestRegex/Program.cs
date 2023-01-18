using TestRegex;
using TestRegex.Functions;

#region[Regex Match List]
string phonesBr = @"Lista telefônica:
-sduiasdfu rgvfiogri 2344231 44446-454 (11) 98756-1212
-98765-4321 uidosfh duhduigohdfuioHE 
-1125344552 11 9 8324-2011
- (11) 9 5510-8105
-11 94444-3333
- 1193655-4141
-(11)96577-1020

(25)452566744";

string emails = @"Os e-mails dos convidados são:

- usdfuyasdiofy iisdfoi sidsaduio@dofis.dfd fulano@cod3r.com.br
-xico@gmail.com
- rmonteiro@brasilcash.com.br
-prefeitura123@prefeitura.org.br
-   mart4463@outlook.com
";

string CPFs = @"CPF dos aprovados:
- asudiodu 600.567.890-12 asidosd
- 765.998.345-23sdadiopo
- xzcsffgcvxzfc159.753.789-12
- 466.697.090-65 fuasdiosdfd";

string RGs = @"CPF dos aprovados:
- asudiodu 48.567.890-3 asidosd
- 23.058.669 sdadiopo
- xzcsffgcvxzfc15.444.333 5
- 21.878.6634 fuasdiosdfd


      33.333.3334";

string CEPs = @"mnjiovdn dsfnjoifgh ?: dffgujwe
g

rhg 06317-050 wejhuiorguob 01234-567 123445567
gfh 44455-22233 254455555-444 fgdeyhrryhh77777-888dfgsrth
";

string CNPJs = @"mnjiovdn dsfnjoifgh ?: dffgujwe
g

rhg 30.507.541/0001-71 wejhuiorguob 00.000.000/0001-01 123445567
gfh 30.507.541/0001-7133 254430.507.541/0001-71 fgdeyhrryhh30.507.541/0001-71dfgsrth
";

//string [] result = SimpleRegexMatchList.PickUpBrazilianPhonesOnAStringInput(phonesBr);
//string[] result2 = SimpleRegexMatchList.GetEmailsInStringInput(emails);
//string[] result2 = SimpleRegexMatchList.GetCPFBrazilianIdentificationOnStringInput(CPFs);
//string[] result2 = SimpleRegexMatchList.GetRGBrazilianIdentificationOnStringInput(RGs);
//string[] result2 = SimpleRegexMatchList.GetBrazilianCEPOnStringInput(CEPs);
//string[] result2 = SimpleRegexMatchList.GetBrazilianCNPJIdentificationOnStringInput(CNPJs);

//foreach (var item in result2)
//{
//    Console.WriteLine(item);
//}

#endregion

#region[Regex Format]
string RemoveTags = @"<div id=""snbc"">

Testando formatação e codigo do regex</div>";

string formatBrazilianPhones = @"
1125344552
11 9 8324-2011
1193655-4141
(11)922554433";

string[] formatBrazilianPhonesList = 
{
    "1125344552",
    "11 9 8324-2011",
    "1193655-4141",
    "(11)922554433"
};

string formatBrazilianPhonesWithoutDDD = @"

98727-8321
9 9342-6623
922443322
9 22443322
5510-8105
55108105";

string[] formatBrazilianPhonesListWithoutDDD =
{
    "98727-8321",
    "9 9342-6623",
    "922443322",
    "9 22443322",
    "5510-8105",
    "55108105"
};

string cpfsFormat = @"
444697018-66
111.222333 66
111.222.333 66
466.555.22244
111222.333-00";

string[] cpfsFormatList =
{
    "444697018-66",
    "111.222333 66",
    "111.222.333 66",
    "466.555.22244",
    "111222.333-00"
};

string rgsFormat = @"
44697018-6
11.222333 6
11.222.333 6
46.555.2224
11222.333-0
11.222.333
11222333";

string[] rgssFormatList =
{
    "44697018-6",
    "11.222333 6",
    "11.222.333 6",
    "46.555.2224",
    "11222.333-0",
    "11222333",

};

string cepFormat = @"
00111-150
06317050
06317 050
06317.050";

string[] cepFormatList =
{
    "00111-150",
    "06317050",
    "06317 050",
    "06317.050"

};

string cnpjFormat = @"
82931873000182
62.447.057/0001-90
62447057/0001-90
624470570001-90
62.447.0570001-90
62.447.057/0001 90
62.447.0570001 90";

string[] cnpjFormatList =
{
    "82931873000182",
    "62.447.057/0001-90",
    "62447057/0001-90",
    "624470570001-90",
    "62.447.0570001-90",
    "62.447.057/0001 90",
    "62.447.0570001 90"
};

//string result = SimpleRegexFormat.RemoveTagsInAnHTMLBody(RemoveTags);
//string result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDByAStringInput(formatBrazilianPhones);
//string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDByAListStringInput(formatBrazilianPhonesList);
//string result = SimpleRegexFormat.FormatBrazilianPhonesWithoutDDDByAStringInput(formatBrazilianPhonesWithoutDDD);
//string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithoutDDDByAListStringInput(formatBrazilianPhonesListWithoutDDD); 
//string result = SimpleRegexFormat.FormatBrazilianIdentityCPFAsString(cpfsFormat);
//string[] result = SimpleRegexFormat.FormatBrazilianIdentityCPFAsStringList(cpfsFormatList);
//string result = SimpleRegexFormat.FormatBrazilianIdentityRGAsString(rgsFormat);
//string[] result = SimpleRegexFormat.FormatBrazilianIdentityRGAsStringList(rgssFormatList);
//string result = SimpleRegexFormat.FormatBrazilianCEPAsString(cepFormat);
//string[] result = SimpleRegexFormat.FormatBrazilianCEPAsStringList(cepFormatList);
//string result = SimpleRegexFormat.FormatBrazilianCPNJAsString(cnpjFormat);
//string[] result = SimpleRegexFormat.FormatBrazilianCPNJAsStringList(cnpjFormatList);

//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine(result);
#endregion

#region[Regex Validations]

string cpf = "529.982.247-25";

string rg = "48.697.590-3";


//bool valid = SimpleRegexValidations.BrazilianCPFValid(cpf);
bool valid = SimpleRegexValidations.BrazilianRGValidSP(rg);
#endregion





