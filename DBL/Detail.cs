using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Detail : EntityLayout
    {
        [Key]
        public override long Id { get; set; } // Поле ключа таблицы (автогенерация)

        public string? Title { get; set; } //  Поле таблицы (необязательно)

        public string? FullName { get; set; } //  Поле таблицы (необязательно)

        public byte[]? Contours { get; set; } //  Поле таблицы (необязательно)

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Contours?.Length.ToString() + " bytes";

    }
};