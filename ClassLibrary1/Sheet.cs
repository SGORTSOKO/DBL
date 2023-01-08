using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Sheet : EntityLayout
    {
        [Key]
        public override long Id { get; set; }

        public string? Title { get; set; }

        public string? FullName { get; set; }

        public float? Width { get; set; }

        public float? Height { get; set; }

        public virtual ICollection<CuttingMap> CuttingMaps { get; } = new List<CuttingMap>();

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Width?.ToString() + ", " + Height?.ToString();

    }
}
