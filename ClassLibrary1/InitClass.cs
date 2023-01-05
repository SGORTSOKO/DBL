namespace DBLib 
{
    public class InitClass 
    {
        public InitClass() 
        {
            using (CuttingContext newDB = new CuttingContext())
            {
                var details = newDB.Details.ToList();
                Console.WriteLine("Objects List");
                foreach (Detail D in details)
                {
                    Console.WriteLine($"{D.Id}, {D.Title}, {D.FullName}");
                }
            }
        }
    }
}
/*
public class InitClass
{
    string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True";
}
*/
//Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cutting" Microsoft.EntityFrameworkCore.SqlServer

