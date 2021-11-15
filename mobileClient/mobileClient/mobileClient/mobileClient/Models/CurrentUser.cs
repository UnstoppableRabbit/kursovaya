using System;
using DataLib.Sqlite.Cache;

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

        public static void GetFromConfig(ref CurrentUser user)
        {
            var usr = CacheContext.Users.GetItem();
            if (usr != null)
            {
                user.Avatar = usr.Avatar;
                user.Birthday = usr.BirthDay;
                user.Email = usr.Email;
                user.NickName = usr.UserName;
            }
        }
        public static void SetToConfig(ref CurrentUser user)
        {
            CacheContext.Users.SaveItem(new User()
            {
                Avatar = user.Avatar,
                BirthDay = user.Birthday,
                Email = user.Email,
                UserName = user.NickName
            });
        }

        public static CurrentUser GetUser()
        {
            return instance ?? (instance = new CurrentUser());
        }
    }
}
