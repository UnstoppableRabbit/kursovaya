using System;
using DataLib.Sqlite.Cache;
using mobileClient.Models;
using mobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KkalCalculatorPage : ContentPage
    {
        KkalCalculatorViewModel _viewModel;
        public KkalCalculatorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new KkalCalculatorViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Refresh();
        }

        private void KkalCalculatorPage_OnDisappearing(object sender, EventArgs e)
        {
            CacheContext.CalculatorCache.DeleteCache();
            int id = 1;
            foreach (var prElem in ProductList.ItemsSource)
            {
                CacheContext.CalculatorCache.SaveItem(new CalculatorCache { Id = id, Weight = ((ProductListElement)prElem).Weight, ProductId = ((ProductListElement)prElem).Id });
                id++;
            }
        }

    }
}