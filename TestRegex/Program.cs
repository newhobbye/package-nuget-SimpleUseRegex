using TestRegex;

string telefone = @"Lista telefônica:
-sduiasdfu rgvfiogri 2344231 44446-454 (11) 98756-1212
-98765-4321 uidosfh duhduigohdfuioHE 
-1125344552 11 9 8324-2011
- (11) 9 5510-8105
-11 94444-3333
- 1193655-4141
-(11)96577-1020

(25)452566744";

string [] result = Replaces.GetPhonesBRInString(telefone);


foreach (var item in result)
{
    Console.WriteLine(item);
}
