using System;

namespace mobileClient.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Foto { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
