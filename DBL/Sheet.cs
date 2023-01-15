using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Sheet : EntityLayout
    {
        public Sheet() { Title = "Undefined"; FullName = "Undefined Full"; }
        public Sheet(string? title, string? fullname, float? width, float? height)
        {
            Title = title;
            FullName = fullname;
            Width = width;
            Height = height;
        }
        [Key]
        public override long Id { get; set; } // Поле ключа таблицы (генерируется автоматически)

        public override string? Title { get; set; } //  Поле таблицы (необязательно)

        public override string? FullName { get; set; }  //  Поле таблицы (необязательно)

        public override float? Width { get; set; }  //  Поле таблицы (необязательно)

        public override float? Height { get; set; }  //  Поле таблицы (необязательно)

        public virtual ICollection<CuttingMap> CuttingMaps { get; } = new List<CuttingMap>();

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Width?.ToString() + ", " + Height?.ToString();

    }
}
