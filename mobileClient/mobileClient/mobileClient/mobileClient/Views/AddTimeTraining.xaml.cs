using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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