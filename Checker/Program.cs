using DBLib; 
Console.WriteLine("Hello, World!");
DBLibrary newInit = new DBLibrary("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = Cutting");

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
Console.WriteLine($"{newInit.ReadObject<Detail>(10)}");
