using System;
using System.Collections.Generic;

namespace DBLib
{

    public partial class CuttingMapDetail
    {
        public long CuttingMapId { get; set; }

        public long DetailId { get; set; }

        public long Id { get; set; }

        public virtual CuttingMap CuttingMap { get; set; } = null!;

        public virtual Detail Detail { get; set; } = null!;
    }
};
