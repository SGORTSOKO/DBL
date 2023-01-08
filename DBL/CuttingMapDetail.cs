using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class CuttingMapDetail : EntityLayout
    {
        [Key]
        public override long Id { get; set; }
        public long CuttingMapId { get; set; }

        public long DetailId { get; set; }

        public virtual CuttingMap CuttingMap { get; set; } = null!;

        public virtual Detail Detail { get; set; } = null!;
        public override string ToString() => Id.ToString() + ", " + CuttingMapId.ToString() + ", " + DetailId.ToString();

    }
};
