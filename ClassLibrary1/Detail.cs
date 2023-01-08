using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class Detail : EntityLayout
    {
        [Key]
        public override long Id { get; set; }

        public string? Title { get; set; } //          ? == null допустим

        public string? FullName { get; set; }

        public byte[]? Contours { get; set; }

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + Contours?.Length.ToString() + " bytes";

    }
};