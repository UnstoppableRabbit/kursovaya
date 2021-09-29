using System;

namespace mobileClient.Models
{
    public class CurrentUser
    {
        private static CurrentUser instance = new CurrentUser();
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        CurrentUser()
        {
        }

        public void SetUser(string nickName, string password)
        {
            //обращение к базе и заполнение инстэнса;
        }

        public void RemoveUser()
        {
            instance = new CurrentUser();
        }

        public CurrentUser GetUser()
        {
            return instance;
        }
    }
}
