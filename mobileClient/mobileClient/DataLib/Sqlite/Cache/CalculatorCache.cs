using SQLite;

namespace DataLib.Sqlite.Cache
{
    [Table("CalculatorCache")]
    public class CalculatorCache
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Weight { get; set; }
    }
}
