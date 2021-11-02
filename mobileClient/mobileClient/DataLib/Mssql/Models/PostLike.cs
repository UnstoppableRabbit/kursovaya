using System;

namespace DataLib.Mssql.Models
{
    public partial class PostLike
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid PostId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Post Post { get; set; }
    }
}
