using System;
using System.Collections.Generic;

namespace DBLib
{

    public partial class Sheet
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? FullName { get; set; }

        public float? Width { get; set; }

        public float? Height { get; set; }

        public virtual ICollection<CuttingMap> CuttingMaps { get; } = new List<CuttingMap>();
    }
}
