using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib
{
    /*
     * Общие свойства сущностей
     * */
    public abstract class EntityLayout// : ICloneable: IDisposable
    {

        [Key]
        public virtual long Id { get; set; }
        public virtual new string ToString() => ""; 
        //public interface IDisposable { void Dispose(); }
        //public virtual object Clone() => MemberwiseClone(); //Переопределить 
    }
}
