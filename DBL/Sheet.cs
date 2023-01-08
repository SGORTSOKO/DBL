using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Sheet : EntityLayout
    {
        [Key]
        public override long Id { get; set; } // Поле ключа таблицы (генерируется автоматически)

        public string? Title { get; set; } //  Поле таблицы (необязательно)

        public string? FullName { get; set; }  //  Поле таблицы (необязательно)

        public float? Width { get; set; }  //  Поле таблицы (необязательно)

        public float? Height { get; set; }  //  Поле таблицы (необязательно)

        public virtual ICollection<CuttingMap> CuttingMaps { get; } = new List<CuttingMap>();

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Width?.ToString() + ", " + Height?.ToString();

    }
}
