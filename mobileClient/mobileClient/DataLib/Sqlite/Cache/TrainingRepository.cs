using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace DataLib.Sqlite.Cache
{
    public class TrainingRepository
    {
        private readonly SQLiteConnection cache;
        public TrainingRepository(string databasePath)
        {
            cache = new SQLiteConnection(databasePath);
            cache.CreateTable<TrainingCache>();
        }
        public IEnumerable<TrainingCache> GetItems()
        {
            return cache.Table<TrainingCache>().ToList();
        }
        public TrainingCache GetItem(int id)
        {
            return cache.Get<TrainingCache>(id);
        }
        public int DeleteItem(int id)
        {
            return cache.Delete<TrainingCache>(id);
        }
        public int DeleteCache()
        {
            return cache.DeleteAll<TrainingCache>();
        }

        public int SaveItem(TrainingCache item)
        {
            if (item.Id == 0)
            {
                item.Id = NewId();
            }
            return cache.Insert(item);
        }
        public int NewId()
        {
            if (!GetItems().Any())
                return 1;
            return GetItems().Max(_ => _.Id) + 1;
        }
    }
}
