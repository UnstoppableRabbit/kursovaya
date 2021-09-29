using System;
using System.IO;

namespace DataLib.Sqlite
{
    public static class ProductContext
    {
        private const string DATABASE_NAME = "products.db";
        private static ProductRepository products;
        private static TrainingRepository training;
        public static ProductRepository Products =>
            products ?? (products = new ProductRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));

        public static TrainingRepository Trainings =>
            training ?? (training = new TrainingRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));
    }
}
