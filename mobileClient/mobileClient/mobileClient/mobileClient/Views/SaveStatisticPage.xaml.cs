using mobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveStatisticPage : ContentPage
    {
        SaveStatisticViewModel _viewModel;
        public SaveStatisticPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SaveStatisticViewModel();
        }
    }
}