using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace DataLib.Sqlite.Cache
{
    public class UserRepository
    {
        private readonly SQLiteConnection cache;
        public UserRepository(string databasePath)
        {
            cache = new SQLiteConnection(databasePath);
            cache.CreateTable<User>();
        }
        private IEnumerable<User> GetItems()
        {
            return cache.Table<User>().ToList();
        }
        public User GetItem()
        {
            try
            {
                return cache.Get<User>(1);
            }
            catch
            {
                return null;
            }
        }
        public int DeleteCache()
        {
            return cache.DeleteAll<User>();
        }

        public int SaveItem(User item)
        {
            if (item.Id != 1)
            {
                item.Id = 1;
            }

            if (IsNotEmpty())
            {
                DeleteCache();
            }
            return cache.Insert(item);
        }

        public bool IsNotEmpty()
        {
            return GetItems().Any();
        }
    }
}