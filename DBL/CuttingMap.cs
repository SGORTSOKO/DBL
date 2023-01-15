using System.ComponentModel.DataAnnotations;

namespace DBLib
{

    public partial class CuttingMap : EntityLayout
    {

        public CuttingMap() { Title = "Undefined"; FullName = "Undefined Full"; }

        public CuttingMap(string? title, string? fullname)
        {
            this.Title = title;
            this.FullName = fullname;
        }

        public CuttingMap(string? title, string? fullname, long? materialid, long? sheetid) 
        { 
            Title = title; 
            FullName = fullname; 
            MaterialId = materialid;
            SheetId = sheetid;
        }
        public CuttingMap(string? title, string? fullname, EntityLayout material, EntityLayout sheet)
        {
            Title = title;
            FullName = fullname;
            MaterialId = material.Id;
            SheetId = sheet.Id;
        }
        [Key]
        public override long Id { get; set; } //Поле ключа таблицы (генерируется автоматически)
        public override string? Title { get; set; } //Поле таблицы (необязательное)

        public override string? FullName { get; set; }  //Поле таблицы (необязательное)

        public override long? MaterialId { get; set; }  //Поле таблицы (необязательное)

        public override long? SheetId { get; set; }  //Поле таблицы (необязательное)

        public virtual ICollection<CuttingMapDetail> CuttingMapDetails { get; } = new List<CuttingMapDetail>();

        public virtual Material? Material { get; set; }

        public virtual Sheet? Sheet { get; set; }

        public override string ToString() => Id.ToString() + ", " + Title?.ToString() + ", " + FullName?.ToString() + ", " + MaterialId?.ToString() + ", " + SheetId?.ToString();

    }
};