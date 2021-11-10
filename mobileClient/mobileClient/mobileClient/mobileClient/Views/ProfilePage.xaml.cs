using mobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfilePageViewModel _viewModel;
        public ProfilePage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new ProfilePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.UpdateData();
        }
    }
}