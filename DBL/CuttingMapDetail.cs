using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class CuttingMapDetail : EntityLayout
    {
        [Key]
        public override long Id { get; set; } // Поле ключа таблицы (генерируется автоматически)
        public long CuttingMapId { get; set; } // Поле таблицы (обязательное)

        public long DetailId { get; set; } // Поле таблицы (обязательное)

        public virtual CuttingMap CuttingMap { get; set; } = null!;

        public virtual Detail Detail { get; set; } = null!;
        public override string ToString() => Id.ToString() + ", " + CuttingMapId.ToString() + ", " + DetailId.ToString();

    }
};
