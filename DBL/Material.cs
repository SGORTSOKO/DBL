using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Material : EntityLayout
    {
        public Material() { Title = "Undefined"; FullName = "Undefined Full"; }
        public Material(string? title, string? fullname, float? thick)
        {
            Title = title;
            FullName = fullname;
            Thick = thick;
        }
        [Key]
        public override long Id { get; set; } //  Поле ключа таблицы (автогенерация)

        public override string? Title { get; set; } //  Поле таблицы (необязательно)

        public override string? FullName { get; set; } //  Поле таблицы (необязательно)

        public override float? Thick { get; set; } //  Поле таблицы (необязательно)

        public virtual ICollection<CuttingMap> CuttingMaps { get; } = new List<CuttingMap>();
        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Thick?.ToString();

    }
};
