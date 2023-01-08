
namespace DBLib 
{
    public class DBLibrary : CuttingContext
    {
        public DBLibrary(string currentserver) : base(currentserver) => Database.EnsureCreated(); //Гарантия, что БД существует (иначе создать) (или await Database.EnsureCreatedAsync()), если есть, то возвращает true// Database.EnsureDeleted() и await Database.EnsureDeletedAsync() - удаление (можно использовать для пересоздания БД)//Database.CanConnect() и await Database.CanConnectAsync() - узнать доступность БД
        
        public T CreateObject<T>(T currentobject) where T:  EntityLayout //Добавить один объект
        { 
            this.Add<T>(currentobject);
            this.SaveChanges(); //Сохранение изменений в БД
            return currentobject;
        }
        public List<T> CreateObjects<T>(List<T> currentobjects) where T : EntityLayout //Добавить список объектов
        {
            List<long> timed = new();
            this.AddRange(currentobjects);
            this.SaveChanges(); //Сохранение изменений в БД
            return currentobjects;
        }
        public string ReadObjectStr<T>(long id) where T : EntityLayout  //Прочитать объект по индексу в таблице сущностей и вернуть строкой
        {
            return Find<T>(id)?.ToString() ?? "Not Found";
        }
        public List<string> ReadObjectsStr<T>(List<long> ids) where T : EntityLayout //Прочитать объекты по индексам в таблице сущностей и вернуть списком строк
        {
            List<string> timed = new();
            ids.ForEach(obj => timed.Add(Find<T>(obj)?.ToString() ?? "Not Found"));
            return timed;
        }
        public T ReadObject<T>(long id) where T : EntityLayout, new() //Прочитать объект по индексу в таблице сущностей и вернуть объектом
        {
            return Find<T>(id) ?? new T();
        }
        public List<T> ReadObjects<T>(List<long> ids) where T : EntityLayout, new() //Прочитать объекты по индексам в таблице сущностей и вернуть объектами
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
        public T UpdateObject<T>(T currentobject) where T : EntityLayout //Перезаписать объект, совпадающий с currentobject по ключу (если объект не существует, то добавить новый)
        {
            Update(currentobject);
            this.SaveChanges(); //Сохранение изменений в БД
            return currentobject;
        }
        public List<T> UpdateObjects<T>(List<T> currentobjects) where T : EntityLayout //Перезаписать объекты
        {
            UpdateRange(currentobjects);
            this.SaveChanges(); //Сохранение изменений в БД
            return currentobjects;
        }
        public void RemoveObject<T>(T currentobject) where T : EntityLayout //Удалить объект
        {
            Remove(currentobject);
            this.SaveChanges(); //Сохранение изменений в БД
        }
        public void RemoveObjectss<T>(List<T> currentobjects) where T : EntityLayout //Удалить объекты
        {
            Remove(currentobjects);
            this.SaveChanges(); //Сохранение изменений в БД
        }
        public void RemoveObjectId<T>(long id) where T : EntityLayout //Удалить объект по индексу
        {
            if (Find<T>(id) is not null)
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                Remove<T>(Find<T>(id));
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            this.SaveChanges(); //Сохранение изменений в БД
        }
        public void RemoveObjectssId<T>(List<T> ids) where T : EntityLayout //Удалить объекты по индексам
        {
            foreach(T id in ids)
            {
                if (Find<T>(id) is not null)
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                    Remove<T>(Find<T>(id));
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                this.SaveChanges(); //Сохранение изменений в БД
            }
        }
        public string CreateDBCatalog() //Создать каталог базы данных 
        {
            if (this.Database.EnsureCreated())
                return "DB has been created";
            else
                return "DB was not changed";
        }
        public string DeleteDBCatalog()
        {
            if (this.Database.EnsureDeleted()) //Удалить каталог базы данных 
                return "DB has been deleted";
            else
                return "DB did not exist";
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

//работает с EntityFrameworkCore.Tools :       https://metanit.com/sharp/efcore/1.3.php
//Генерация кода из структуры БД
//Следующий код вводить в "Консоль Диспетчера Пакетов"
// Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cutting" Microsoft.EntityFrameworkCore.SqlServer
// или
// Scaffold-DbContext "Data Source=D:\\helloapp.db" Microsoft.EntityFrameworkCore.Sqlite
//структура:
//"метод" "параметры (адрес бд)" "кто генерирует" 

