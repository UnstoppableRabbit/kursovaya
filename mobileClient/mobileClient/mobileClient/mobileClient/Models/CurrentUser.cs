using System;

namespace mobileClient.Models
{
    public class CurrentUser
    {
        private static CurrentUser instance;
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        private CurrentUser()
        {
        }

        public void SetUser(string nickName, string password)
        {
            //обращение к базе и заполнение инстэнса;
        }

        public static CurrentUser GetUser()
        {
            return instance ?? (instance = new CurrentUser());
        }
    }
}
