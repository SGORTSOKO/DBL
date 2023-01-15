using System.ComponentModel.DataAnnotations;

namespace DBLib
{
    public abstract class EntityLayout// Абстрактный класс, родительский всем моделям базы данных                                         На будущее, сделать: ICloneable: IDisposable
    {

        [Key] //Ключ
        public virtual long Id { get; set; } //Ключ таблиц

        public virtual long? MaterialId { get;  set; }

        public virtual string? Title { get; set; }
        public virtual string? FullName { get; set; }

        public virtual long? SheetId { get; set; }

        public virtual long CuttingMapId { get; set; }

        public virtual long DetailId { get; set; }

        public virtual byte[]? Contours { get; set; }

        public virtual float? Thick { get; set; }

        public virtual float? Width { get; set; }

        public virtual float? Height { get; set; }

        public virtual new string ToString() => ""; //Определение метода для преобразования к строке

        public static void Union(EntityLayout first, EntityLayout second) 
        {
            switch (first)
            {
                case CuttingMap:
                    switch (second)
                    {
                        case Material:
                            first.MaterialId = second.Id;
                            Console.WriteLine("CuttingMap + Material");
                            break;
                        case Sheet:
                            first.SheetId = second.Id;
                            Console.WriteLine("CuttingMap + Sheet");
                            break;
                        case CuttingMapDetail:
                            second.CuttingMapId = first.CuttingMapId;
                            Console.WriteLine("CuttingMap + CuttingMapDetail");
                            break;
                    }
                    break;
                case CuttingMapDetail:
                    switch (second)
                    {
                        case Detail:
                            first.DetailId = second.Id;
                            Console.WriteLine("CuttingMapDetail + Detail");
                            break;
                        case CuttingMap:
                            first.CuttingMapId = second.Id;
                            Console.WriteLine("CuttingMapDetail + CuttingMap");
                            break;
                    }
                    break;
                case Detail:
                    second.CuttingMapId = first.Id;
                    Console.WriteLine("Detail + CuttingMapDetail");
                    break;
                case Material:
                    break;
                case Sheet:
                    break;
            }
        }
        //public interface IDisposable { void Dispose(); }
        //public virtual object Clone() => MemberwiseClone(); //Переопределить 
        /*
        public static long? operator +(EntityLayout cuttingmap, Material material) => cuttingmap.Id + material.Id;
        public static int operator +(CuttingMap cuttingmap, Sheet sheet)
        {

        }
        */
    }
}
