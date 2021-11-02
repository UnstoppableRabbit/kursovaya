using System;
using System.Collections.Generic;

namespace DataLib.Mssql.Models
{
    public partial class Person
    {
        public Person()
        {
            Diets = new HashSet<Diet>();
            InverseCoach = new HashSet<Person>();
            PersonSportLogs = new HashSet<PersonSportLog>();
            PostLikes = new HashSet<PostLike>();
            Posts = new HashSet<Post>();
            Training = new HashSet<Training>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public bool IsCoach { get; set; }
        public Guid? CoachId { get; set; }

        public virtual Person Coach { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual ICollection<Person> InverseCoach { get; set; }
        public virtual ICollection<PersonSportLog> PersonSportLogs { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Training> Training { get; set; }
    }
}
