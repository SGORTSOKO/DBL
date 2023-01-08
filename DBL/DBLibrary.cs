using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace DBLib 
{
    public class DBLibrary : CuttingContext
    {
        public DBLibrary(string currentserver) : base(currentserver) => Database.EnsureCreated(); //Гарантия, что БД существует (иначе создать) (или await Database.EnsureCreatedAsync()), если есть, то возвращает true// Database.EnsureDeleted() и await Database.EnsureDeletedAsync() - удаление (можно использовать для пересоздания БД)//Database.CanConnect() и await Database.CanConnectAsync() - узнать доступность БД
        
        public T CreateObject<T>(T currentobject) where T:  EntityLayout
        { 
            this.Add<T>(currentobject);
            this.SaveChanges();
            return currentobject;
        }
        public List<T> CreateObjects<T>(List<T> currentobjects) where T : EntityLayout
        {
            List<long> timed = new();
            this.AddRange(currentobjects);
            this.SaveChanges();
            return currentobjects;
        }
        public string ReadObjectStr<T>(long id) where T : EntityLayout
        {
            return Find<T>(id)?.ToString() ?? "Not Found";
        }
        public List<string> ReadObjectsStr<T>(List<long> ids) where T : EntityLayout
        {
            List<string> timed = new();
            ids.ForEach(obj => timed.Add(Find<T>(obj)?.ToString() ?? "Not Found"));
            return timed;
        }
        public T ReadObject<T>(long id) where T : EntityLayout, new()
        {
            return Find<T>(id) ?? new T();
        }
        public List<T> ReadObjects<T>(List<long> ids) where T : EntityLayout, new()
        {
            List<T> timed = new();
            foreach (long obj in ids) 
            {
                if (Find<T>(obj) is not null)
                {
                    timed.Add(Find<T>(obj) ?? new T());
                }
            }
            return timed;
        }
        public T UpdateObject<T>(T currentobject) where T : EntityLayout
        {
            Update(currentobject);
            this.SaveChanges();
            return currentobject;
        }
        public List<T> UpdateObjects<T>(List<T> currentobjects) where T : EntityLayout
        {
            UpdateRange(currentobjects);
            this.SaveChanges();
            return currentobjects;
        }
        public void RemoveObject<T>(T currentobject) where T : EntityLayout
        {
            Remove(currentobject);
            this.SaveChanges();
        }
        public void RemoveObjectss<T>(List<T> currentobjects) where T : EntityLayout
        {
            Remove(currentobjects);
            this.SaveChanges();
        }
        public void RemoveObjectId<T>(long id) where T : EntityLayout
        {
            if (Find<T>(id) is not null)
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                Remove<T>(Find<T>(id));
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            this.SaveChanges();
        }
        public void RemoveObjectssId<T>(List<T> ids) where T : EntityLayout
        {
            foreach(T id in ids)
            {
                if (Find<T>(id) is not null)
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                    Remove<T>(Find<T>(id));
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                this.SaveChanges();
            }
        }
        public string CreateDBCatalog()
        {
            if (this.Database.EnsureCreated())
                return "DB has been created";
            else
                return "DB was not created";
        }
        public string DeleteDBCatalog()
        {
            if (this.Database.EnsureDeleted())
                return "DB has been deleted";
            else
                return "DB was not deleted";
        }
        public string GenerateDBRandomData()
        {

            return "Data Generated";
        }


    }
}
/*
public class InitClass
{
    string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True";
}
*/
//Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cutting" Microsoft.EntityFrameworkCore.SqlServer - cs classes generation from DB
