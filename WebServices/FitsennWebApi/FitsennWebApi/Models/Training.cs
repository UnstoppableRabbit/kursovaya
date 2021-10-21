using System;
using System.Collections.Generic;

#nullable disable

namespace FitsennWebApi.Models
{
    public partial class Training
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public double TotalCalories { get; set; }

        public virtual Person Person { get; set; }
    }
}
