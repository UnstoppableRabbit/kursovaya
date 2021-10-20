using System;
using System.IO;

namespace DataLib.Sqlite.Cache
{
    public class CacheContext
    {
        private const string DATABASE_NAME = "products.db";
        private static CacheRepository calculatorCache;
        private static TrainingRepository trainingCache;

        public static CacheRepository CalculatorCache =>
            calculatorCache ?? (calculatorCache = new CacheRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));
        public static TrainingRepository TrainingCache =>
            trainingCache ?? (trainingCache = new TrainingRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));
    }
}
