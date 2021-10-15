using System.ComponentModel;
using SQLite;

namespace DataLib.Sqlite.Model
{
    [Table("Training")]
    public class Training
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRepeated { get; set; }

        [Description("В зависимости от типа - сжигание калорий за повторение или за минуту")]
        public double Calories { get; set; }
    }
}
