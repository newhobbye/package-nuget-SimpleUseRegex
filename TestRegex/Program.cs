﻿using TestRegex;
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



//string result = SimpleRegexFormat.RemoveTagsInAnHTMLBody(RemoveTags);
//string result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDByAStringInput(formatBrazilianPhones);
string[] result = SimpleRegexFormat.FormatBrazilianPhonesWithDDDByAListStringInput(formatBrazilianPhonesList);

foreach (var item in result)
{
    Console.WriteLine(item);
}

//Console.WriteLine(result);
#endregion





