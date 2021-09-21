using SQLite;

namespace DataLib.Sqlite.Cache
{
    [Table("CalculatorCache")]
    public class CalculatorCache
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Weight { get; set; }
    }
}
