using System;
using System.Collections.Generic;

namespace DBLib
{

    public partial class CuttingMap
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? FullName { get; set; }

        public long? MaterialId { get; set; }

        public long? SheetId { get; set; }

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();

        public virtual Material? Material { get; set; }

        public virtual Sheet? Sheet { get; set; }
    }
};