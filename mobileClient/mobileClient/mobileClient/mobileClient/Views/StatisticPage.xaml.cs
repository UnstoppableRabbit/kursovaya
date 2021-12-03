using mobileClient.Models;
using mobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticPage : ContentPage
    {
        StatisticPageViewModel _viewModel;
        public StatisticPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new StatisticPageViewModel();
        }
    }
}