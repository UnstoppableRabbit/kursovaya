using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DataLib.Sqlite;
using DataLib.Sqlite.Cache;
using DataLib.Sqlite.Model;
using mobileClient.Models;
using mobileClient.Views;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class KkalCalculatorViewModel : BaseViewModel
    {
        private int _selectedWeight;
        private double _totalCalories;
        private Product _selectedProduct;
        private ProductListElement _currentProduct;
        private bool _canAddProduct;
        private bool _canDeleteCurrent;
        private bool _canClear;

        public KkalCalculatorViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            Products = new ObservableCollection<Product>(ProductContext.Database.GetItems());
            ProductList = new ObservableCollection<ProductListElement>();
            foreach (var cacheElem in CacheContext.Cache.GetItems())
            {
                ProductList.Add(new ProductListElement(Products.First(_ => _.Id.Equals(cacheElem.ProductId)), cacheElem.Weight));
            }
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

        public ProductListElement CurrentProduct
        {
            get => _currentProduct;
            set
            {
                SetProperty(ref _currentProduct, value);
                CanDeleteCurrent = CurrentProduct != null;
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

        public bool CanDeleteCurrent
        {
            get => _canDeleteCurrent;
            set => SetProperty(ref _canDeleteCurrent, value);
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

        public ICommand DeleteCurrentCommand =>
            new Command(() =>
            {
                ProductList.Remove(CurrentProduct);
                ClearView();
            });

        public ICommand AddItemCommand =>
            new Command(OnAddItem);

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewProductPage));
        }

        public ICommand RefreshCommand =>
            new Command(Refresh);
        private void ClearView()
        {
            TotalCalories = ProductList.Sum(_ => _.TotalCalories);
            SelectedWeight = 0;
            SelectedProduct = null;
            CurrentProduct = null;
            CanAddProduct = false;
            CanClear = ProductList.Count > 0;
            CanDeleteCurrent = false;
        }
    }
}
