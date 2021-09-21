using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLib.Sqlite.Cache
{
    public class CacheContext
    {
        private const string DATABASE_NAME = "products.db";
        private static CacheRepository cache;

        public static CacheRepository Cache =>
            cache ?? (cache = new CacheRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));
    }
}
