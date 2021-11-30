using System;

namespace DataLib.Mssql.Models
{
    public partial class PersonSportLog
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }

        public virtual Person Person { get; set; }
    }
}
