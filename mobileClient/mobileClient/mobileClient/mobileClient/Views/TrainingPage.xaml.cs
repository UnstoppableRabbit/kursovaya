using mobileClient.ViewModels;
using Xamarin.Forms;

namespace mobileClient.Views
{
    public partial class TrainigPage : ContentPage
    {
        TrainingPageViewModel _viewModel;
        public TrainigPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new TrainingPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Refresh();
        }

    }
}