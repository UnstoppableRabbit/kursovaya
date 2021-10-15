using SQLite;

namespace DataLib.Sqlite.Model
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
    }
}
