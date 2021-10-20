using SQLite;

namespace DataLib.Sqlite.Cache
{
    [Table("TrainingCache")]
    public class TrainingCache
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int Points { get; set; }
    }
}
