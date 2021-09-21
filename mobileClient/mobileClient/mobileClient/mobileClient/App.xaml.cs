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
            if (!ProductContext.Database.GetItems().Any())
            {
                ProductContext.Database.SaveItem(new Product { Id = 1, Name = "Арбуз", Calories = 0.28 });
                ProductContext.Database.SaveItem(new Product { Id = 2, Name = "Яблоко", Calories = 0.52 });
                ProductContext.Database.SaveItem(new Product { Id = 3, Name = "Куриная грудка", Calories = 1.13 });
                ProductContext.Database.SaveItem(new Product { Id = 4, Name = "Гречка", Calories = 1.1 });
                ProductContext.Database.SaveItem(new Product { Id = 5, Name = "Макароны", Calories = 1.12 });
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
