using System;
using System.IO;

namespace DataLib.Sqlite
{
    public static class ProductContext
    {
        private const string DATABASE_NAME = "products.db";
        private static ProductRepository database;

        public static ProductRepository Database =>
            database ?? (database = new ProductRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));
    }
}
