using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class CuttingMapDetail : EntityLayout
    {
        public CuttingMapDetail() { }
        public CuttingMapDetail(long cuttingmapid, long detailid)
        {
            CuttingMapId = cuttingmapid;
            DetailId = detailid;
        }
        public CuttingMapDetail(EntityLayout cuttingmap, EntityLayout detail)
        {
            CuttingMapId = cuttingmap.Id;
            DetailId = detail.Id;
        }
        [Key]
        public override long Id { get; set; } // Поле ключа таблицы (генерируется автоматически)
        public override long CuttingMapId { get; set; } // Поле таблицы (обязательное)

        public override long DetailId { get; set; } // Поле таблицы (обязательное)

        public virtual CuttingMap CuttingMap { get; set; } = null!;

        public virtual Detail Detail { get; set; } = null!;
        public override string ToString() => Id.ToString() + ", " + CuttingMapId.ToString() + ", " + DetailId.ToString();

    }
};
