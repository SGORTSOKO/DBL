using DBLib;
using System;
using Microsoft.Extensions.Options;

string SSS(int maxlen, int rnd)
{
    string resstring = "";
    while (resstring.Length < 2)
    {
        Random res = new Random();
        rnd = res.Next(-rnd, rnd);
        String strs = " abcdefghijklmnopqrstuvwxyz0123456789-+*/!@#$%^&*()№;:?_=<>,.[]{}";
        for (int i = 0; i < maxlen + rnd; i++)
        {
            resstring += strs[res.Next(strs.Length)];
        }
    }
    return resstring;
}

byte[] modulus =
        {
            214,46,220,83,160,73,40,39,201,155,19,202,3,11,191,178,56,
            74,90,36,248,103,18,144,170,163,145,87,54,61,34,220,222,
            207,137,149,173,14,92,120,206,222,158,28,40,24,30,16,175,
            108,128,35,230,118,40,121,113,125,216,130,11,24,90,48,194,
            240,105,44,76,34,57,249,228,125,80,38,9,136,29,117,207,139,
            168,181,85,137,126,10,126,242,120,247,121,8,100,12,201,171,
            38,226,193,180,190,117,177,87,143,242,213,11,44,180,113,93,
            106,99,179,68,175,211,164,116,64,148,226,254,172,147
        };



Console.WriteLine("Hello, World!");
DBLibrary newInit = new DBLibrary("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = Cutting");
CuttingMap cuttingMap = new CuttingMap() { Title = "First Cutting Map", FullName = SSS(65, 35) };
Detail detail = new Detail() { Title = "First Detail", FullName = SSS(55, 25) };
Material material = new Material() { Title = "Fisrt Material", FullName = SSS(65, 25) };
Sheet sheet = new Sheet() { Title = "Fisrt Sheet", FullName = SSS(65, 25) };
CuttingMapDetail cuttingMapDetail = new CuttingMapDetail();
EntityLayout.Union(sheet, sheet);
/*
for (int i = 0; i < 100; i++) 
    {
    newInit.CreateObject(new Detail() { Title = SSS(30, 12), FullName = SSS(80, 35) });
    }
*/


/*
Detail TD1 = new Detail { Title = "Standart", FullName = "Standart Detail Number 2", Contours = modulus };
Detail TD2 = new Detail { Title = "Standart", FullName = "Standart Detail Number 2", Contours = modulus };
Detail TD3 = new Detail { Title = "Standart", FullName = "Standart Detail Number 2", Contours = modulus };
Detail TD4 = new Detail { Title = "Standart", FullName = "Standart Detail Number 2", Contours = modulus };
List<Detail> det = new List<Detail>();
det.Add(TD1);
det.Add(TD2);
det.Add(TD3);
det.Add(TD4);
List<long> timed = newInit.CreateObject<Detail>(det);
foreach (long D in timed)
{
    Console.WriteLine($"{D}");
}
var details = newInit.Details.ToList();
Console.WriteLine("Objects List");
foreach (Detail D in details)
{
    Console.WriteLine($"{D.Title}, {D.FullName}, {D.Contours}");
}
*/
//Console.WriteLine($"{newInit.ReadObject<Detail>(10)}");
