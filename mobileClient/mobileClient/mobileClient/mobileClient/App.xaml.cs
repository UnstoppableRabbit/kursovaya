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
            if (!ProductContext.Products.GetItems().Any())
            {
                ProductContext.Products.SaveItem(new Product { Id = 1, Name = "Арбуз", Calories = 0.28 });
                ProductContext.Products.SaveItem(new Product { Id = 2, Name = "Яблоко", Calories = 0.52 });
                ProductContext.Products.SaveItem(new Product { Id = 3, Name = "Куриная грудка", Calories = 1.13 });
                ProductContext.Products.SaveItem(new Product { Id = 4, Name = "Гречка", Calories = 1.1 });
                ProductContext.Products.SaveItem(new Product { Id = 5, Name = "Макароны", Calories = 1.12 });
            }
            if (!ProductContext.Trainings.GetItems().Any())
            {
                ProductContext.Trainings.SaveItem(new Training { Id = 1, Name = "Отжимание", IsRepeated = true, Calories = 0.1 });
                ProductContext.Trainings.SaveItem(new Training { Id = 2, Name = "Приседание", IsRepeated = true, Calories = 0.35 });
                ProductContext.Trainings.SaveItem(new Training { Id = 3, Name = "Бег 8 км/ч", IsRepeated = false, Calories = 11 / 60 });
                ProductContext.Trainings.SaveItem(new Training { Id = 4, Name = "Бег 10 км/ч", IsRepeated = false, Calories = 13 / 60 });
                ProductContext.Trainings.SaveItem(new Training { Id = 5, Name = "Бег 15 км/ч", IsRepeated = false, Calories = 18 / 60 });
                ProductContext.Trainings.SaveItem(new Training { Id = 6, Name = "Ходьба", IsRepeated = false, Calories = 5 / 60 });
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
