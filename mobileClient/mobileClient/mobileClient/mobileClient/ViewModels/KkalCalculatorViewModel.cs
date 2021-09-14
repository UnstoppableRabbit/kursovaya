using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DataLib.Sqlite.Model;
using mobileClient.Models;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class KkalCalculatorViewModel : BaseViewModel
    {
        private int _selectedWeight;
        private double _totalCalories;
        private Product _selectedProduct;
        private bool _canAddProduct;
        private bool _canClear;

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

            ClearView();
        }

        public double TotalCalories
        {
            get => _totalCalories; 
            set => SetProperty(ref _totalCalories, value);
        }
        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<ProductListElement> ProductList { get; set; }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                CanAddProduct = true;
            }
        }

        public int SelectedWeight
        {
            get => _selectedWeight ;
            set => SetProperty(ref _selectedWeight, value);
        }

        public bool CanAddProduct
        {
            get => _canAddProduct;
            set => SetProperty(ref _canAddProduct, value);
        }

        public bool CanClear
        {
            get => _canClear;
            set => SetProperty(ref _canClear, value);
        }

        public ICommand AddProductCommand =>
            new Command(() =>
            {
                ProductList.Add(new ProductListElement(SelectedProduct, SelectedWeight));
                ClearView();
            });

        public ICommand ClearProductCommand => 
            new Command(() =>
            {
                ProductList.Clear();
                ClearView();
            });

        private void ClearView()
        {
            TotalCalories = ProductList.Sum(_ => _.TotalCalories);
            SelectedWeight = 0;
            SelectedProduct = null;
            CanAddProduct = false;
            CanClear = ProductList.Count > 0;
        }
    }
}
