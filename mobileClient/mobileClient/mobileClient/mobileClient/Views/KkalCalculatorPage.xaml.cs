using System;
using DataLib.Sqlite.Cache;
using mobileClient.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KkalCalculatorPage : ContentPage
    {
        public KkalCalculatorPage()
        {
            InitializeComponent();
        }

        private void KkalCalculatorPage_OnDisappearing(object sender, EventArgs e)
        {
            CacheContext.Cache.DeleteCache();
            int id = 1;
            foreach (var prElem in ProductList.ItemsSource)
            {
                CacheContext.Cache.SaveItem(new CalculatorCache { Id = id, Weight = ((ProductListElement)prElem).Weight, ProductId = ((ProductListElement)prElem).Id });
                id++;
            }
        }
    }
}