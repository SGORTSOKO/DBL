using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Material : EntityLayout
    {
        [Key]
        public override long Id { get; set; }

        public string? Title { get; set; }

        public string? FullName { get; set; }

        public float? Thick { get; set; }

        public virtual ICollection<CuttingMap> CuttingMaps { get; } = new List<CuttingMap>();
        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Thick?.ToString();

    }
};
