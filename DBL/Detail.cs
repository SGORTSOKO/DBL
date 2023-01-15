using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Detail : EntityLayout
    {
        public Detail() { Title = "Undefined"; FullName = "Undefined Full"; }
        public Detail(string? title, string? fullname, byte[]? contours)
        {
            Title = title;
            FullName = fullname;
            Contours = contours;
        }
        [Key]
        public override long Id { get; set; } // Поле ключа таблицы (автогенерация)

        public override string? Title { get; set; } //  Поле таблицы (необязательно)

        public override string? FullName { get; set; } //  Поле таблицы (необязательно)

        public override byte[]? Contours { get; set; } //  Поле таблицы (необязательно)

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Contours?.Length.ToString() + " bytes";

    }
};