using System;
using SQLite;

namespace DataLib.Sqlite.Cache
{
    [Table("CurrentUser")]
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
