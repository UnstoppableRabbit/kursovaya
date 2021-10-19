using mobileClient.ViewModels;
using Xamarin.Forms;

namespace mobileClient.Views
{
    public partial class AddTimeTraining : ContentPage
    {
        public AddTimeTraining()
        {
            InitializeComponent();
            BindingContext = new AddTimeTrainingViewModel();
        }
    }
}