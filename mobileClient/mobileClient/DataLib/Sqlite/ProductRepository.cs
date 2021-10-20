using System.Collections.Generic;
using System.Linq;
using DataLib.Sqlite.Model;
using SQLite;

namespace DataLib.Sqlite
{
    public class ProductRepository
    {
        private readonly SQLiteConnection database;
        public ProductRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Product>();
        }
        public IEnumerable<Product> GetItems()
        {
            return database.Table<Product>().ToList();
        }
        public Product GetItem(int id)
        {
            return database.Get<Product>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Product>(id);
        }
        public int SaveItem(Product item)
        {
            if (item.Id == 0)
            {
                item.Id = NewId();
            }
            return database.Insert(item);
        }
        public int NewId()
        {
            if (!GetItems().Any())
                return 1;
            return GetItems().Max(_ => _.Id) + 1;
        }
    }
}
