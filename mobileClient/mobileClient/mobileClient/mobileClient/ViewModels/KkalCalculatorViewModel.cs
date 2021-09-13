using System.Collections.ObjectModel;
using System.Linq;
using DataLib.Sqlite.Model;
using mobileClient.Models;

namespace mobileClient.ViewModels
{
    public class KkalCalculatorViewModel : BaseViewModel
    {
        public KkalCalculatorViewModel()
        {
            Products = new ObservableCollection<Product>()
            {
                new Product {Name = "Яблоко", Calories = 120}
            };

            ProductList = new ObservableCollection<ProductListElement>()
            {
                new ProductListElement(Products.First(), 1000)
            };

        }
        
        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<ProductListElement> ProductList { get; set; }
    }
}
