using System;
using System.Collections.Generic;

namespace DataLib.Mssql.Models
{
    public partial class Post
    {
        public Post()
        {
            PostLikes = new HashSet<PostLike>();
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid CreatorId { get; set; }
        public string Foto { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public virtual Person Creator { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
    }
}
