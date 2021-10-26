using mobileClient.Views;
using Xamarin.Forms;

namespace mobileClient
{
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewProductPage), typeof(NewProductPage));
            Routing.RegisterRoute(nameof(AddTimeTraining), typeof(AddTimeTraining));
            Routing.RegisterRoute(nameof(NewTrainingPage), typeof(NewTrainingPage));
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
