using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib.Sqlite.Model;
using SQLite;

namespace DataLib.Sqlite
{
    public class TrainingRepository
    {
        private readonly SQLiteConnection database;
        public TrainingRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Training>();
        }
        public IEnumerable<Training> GetItems()
        {
            return database.Table<Training>().ToList();
        }
        public Training GetItem(int id)
        {
            return database.Get<Training>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Training>(id);
        }
        public int SaveItem(Training item)
        {
            if (item.Id == 0)
            {
                item.Id = NewId();
            }
            return database.Insert(item);
        }
        public int NewId()
        {
            return GetItems().Max(_ => _.Id) + 1;
        }
    }
}
