using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class CuttingMap : EntityLayout
    {
        [Key]
        public override long Id { get; set; } //Поле ключа таблицы (генерируется автоматически)
        public string? Title { get; set; } //Поле таблицы (необязательное)

        public string? FullName { get; set; }  //Поле таблицы (необязательное)

        public long? MaterialId { get; set; }  //Поле таблицы (необязательное)

        public long? SheetId { get; set; }  //Поле таблицы (необязательное)

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();

        public virtual Material? Material { get; set; }

        public virtual Sheet? Sheet { get; set; }

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + MaterialId?.ToString() + ", " + SheetId?.ToString();

    }
};