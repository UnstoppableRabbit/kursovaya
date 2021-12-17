using System.Linq;
using DataLib.Sqlite;
using DataLib.Sqlite.Model;
using Xamarin.Forms;

namespace mobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            ProductContext.Products.Clear();

            if (!ProductContext.Products.GetItems().Any())
            {
                ProductContext.Products.SaveItem(new Product { Id = 1, Name = "Арбуз", Calories = 0.28 });
                ProductContext.Products.SaveItem(new Product { Id = 2, Name = "Яблоко", Calories = 0.52 });
                ProductContext.Products.SaveItem(new Product { Id = 3, Name = "Куриная грудка", Calories = 1.13 });
                ProductContext.Products.SaveItem(new Product { Id = 4, Name = "Гречка", Calories = 1.1 });
                ProductContext.Products.SaveItem(new Product { Id = 5, Name = "Макароны", Calories = 1.12 });
                ProductContext.Products.SaveItem(new Product { Id = 6, Name = "Колбаса вареная диетическая", Calories = 1.7 });
                ProductContext.Products.SaveItem(new Product { Id = 7, Name = "Колбаса вареная докторская", Calories = 2.57 });
                ProductContext.Products.SaveItem(new Product { Id = 8, Name = "Колбаса ливерная", Calories = 3.26 });
                ProductContext.Products.SaveItem(new Product { Id = 9, Name = "Абрикос", Calories = 0.44 });
                ProductContext.Products.SaveItem(new Product { Id = 10, Name = "Авокадо", Calories = 2.12 });
                ProductContext.Products.SaveItem(new Product { Id = 11, Name = "Апельсин", Calories = 0.36 });
                ProductContext.Products.SaveItem(new Product { Id = 12, Name = "Хурма", Calories = 0.67 });
                ProductContext.Products.SaveItem(new Product { Id = 13, Name = "Вишня", Calories = 0.52 });
                ProductContext.Products.SaveItem(new Product { Id = 14, Name = "Инжир", Calories = 0.49 });
                ProductContext.Products.SaveItem(new Product { Id = 15, Name = "Торт Сметанно-ореховый", Calories = 2.75 });
                ProductContext.Products.SaveItem(new Product { Id = 16, Name = "Мороженое молочное", Calories = 1.26 });
                ProductContext.Products.SaveItem(new Product { Id = 17, Name = "Мороженое эскимо", Calories = 2.7 });
                ProductContext.Products.SaveItem(new Product { Id = 18, Name = "Мороженое пломбир", Calories = 2.27 });
                ProductContext.Products.SaveItem(new Product { Id = 19, Name = "Вино белое сухое", Calories = 0.66 });
                ProductContext.Products.SaveItem(new Product { Id = 20, Name = "Водка", Calories = 2.35 });
                ProductContext.Products.SaveItem(new Product { Id = 21, Name = "Кола", Calories = 0.42 });
                ProductContext.Products.SaveItem(new Product { Id = 22, Name = "Кофе капучино", Calories = 0.32 });
                ProductContext.Products.SaveItem(new Product { Id = 23, Name = "Чай чёрный с сахаром", Calories = 0.25 });
                ProductContext.Products.SaveItem(new Product { Id = 24, Name = "Борщ украинский", Calories = 0.49 });
                ProductContext.Products.SaveItem(new Product { Id = 25, Name = "Свекольник", Calories = 0.36 });
                ProductContext.Products.SaveItem(new Product { Id = 26, Name = "Суп гороховый", Calories = 0.66 });
                ProductContext.Products.SaveItem(new Product { Id = 27, Name = "Салат Витаминный готовый", Calories = 1.46 });
                ProductContext.Products.SaveItem(new Product { Id = 28, Name = "Салат Мимоза готовый", Calories = 1.83 });
                ProductContext.Products.SaveItem(new Product { Id = 29, Name = "Салат Оливье с колбасой готовый", Calories = 1.98 });
                ProductContext.Products.SaveItem(new Product { Id = 30, Name = "Сельдь под шубой готовая", Calories = 1.93 });
                ProductContext.Products.SaveItem(new Product { Id = 31, Name = "Баранина", Calories = 2.09 });
                ProductContext.Products.SaveItem(new Product { Id = 32, Name = "Говядина", Calories = 1.87 });
                ProductContext.Products.SaveItem(new Product { Id = 33, Name = "Индейка (грудка)", Calories = 0.84 });
                ProductContext.Products.SaveItem(new Product { Id = 34, Name = "Рис", Calories = 3.33 });
                ProductContext.Products.SaveItem(new Product { Id = 35, Name = "Арахис", Calories = 6.22 });
                ProductContext.Products.SaveItem(new Product { Id = 36, Name = "Грецкий орех", Calories = 6.54 });

            }

            ProductContext.Trainings.Clear();

            if (!ProductContext.Trainings.GetItems().Any())
            {
                ProductContext.Trainings.SaveItem(new Training { Id = 1, Name = "Отжимания", IsRepeated = true, Calories = 6.0 });
                ProductContext.Trainings.SaveItem(new Training { Id = 2, Name = "Приседания", IsRepeated = true, Calories = 2.1 });
                ProductContext.Trainings.SaveItem(new Training { Id = 3, Name = "Бег 8 км/ч", IsRepeated = false, Calories = 11.0 });
                ProductContext.Trainings.SaveItem(new Training { Id = 4, Name = "Бег 10 км/ч", IsRepeated = false, Calories = 13.0 });
                ProductContext.Trainings.SaveItem(new Training { Id = 5, Name = "Бег 15 км/ч", IsRepeated = false, Calories = 18.0 });
                ProductContext.Trainings.SaveItem(new Training { Id = 6, Name = "Ходьба", IsRepeated = false, Calories = 5.0 });
                ProductContext.Trainings.SaveItem(new Training { Id = 7, Name = "Планка", IsRepeated = false, Calories = 12.0 });
                ProductContext.Trainings.SaveItem(new Training { Id = 8, Name = "Подтягивания", IsRepeated = true, Calories = 0.25 });
                ProductContext.Trainings.SaveItem(new Training { Id = 9, Name = "Становая тяга", IsRepeated = true, Calories = 0.25 });
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
