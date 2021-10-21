using System;
using System.Collections.Generic;

#nullable disable

namespace FitsennWebApi.Models
{
    public partial class PersonSportLog
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }

        public virtual Person Person { get; set; }
    }
}
