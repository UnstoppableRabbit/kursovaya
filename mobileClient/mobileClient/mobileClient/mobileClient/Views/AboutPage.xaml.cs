using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DataLib.Mssql.Models;
using mobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileClient.Views
{
    public partial class AboutPage : ContentPage
    {
        private AboutViewModel _viewModel;
        public AboutPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new AboutViewModel();
        }
    }
}