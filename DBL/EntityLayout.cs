using System.ComponentModel.DataAnnotations;

namespace DBLib
{
    public abstract class EntityLayout// Абстрактный класс, родительский всем моделям базы данных                                         На будущее, сделать: ICloneable: IDisposable
    {

        [Key] //Ключ
        public virtual long Id { get; set; } //Ключ таблиц
        public virtual new string ToString() => ""; //Определение метода для преобразования к строке
        //public interface IDisposable { void Dispose(); }
        //public virtual object Clone() => MemberwiseClone(); //Переопределить 
    }
}
