using System;
using System.Collections.Generic;

namespace DBLib
{

    public partial class Detail
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? FullName { get; set; }

        public byte[]? Contours { get; set; }

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();
    }
};