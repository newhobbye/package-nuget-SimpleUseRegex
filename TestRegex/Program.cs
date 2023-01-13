using TestRegex.Functions;

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

//string [] result = SimpleRegexMatchList.PickUpBrazilianPhonesOnAStringInput(phonesBr);
string[] result2 = SimpleRegexMatchList.GetEmailsInStringInput(emails); 



//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

foreach (var item in result2)
{
    Console.WriteLine(item);
}
