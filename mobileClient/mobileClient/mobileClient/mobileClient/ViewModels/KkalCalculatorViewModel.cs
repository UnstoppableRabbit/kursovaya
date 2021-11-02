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
            if (Products == null)
                Products = new ObservableCollection<Product>(ProductContext.Products.GetItems());
            else
            {
                Products.Clear();

                foreach (var product in ProductContext.Products.GetItems())
                {
                    Products.Add(product);
                }
            }

            if (ProductList == null)
            {
                ProductList = new ObservableCollection<ProductListElement>();
            }
            else
            {
                ProductList.Clear();

                foreach (var cacheElem in CacheContext.CalculatorCache.GetItems())
                {
                    var k = Products.FirstOrDefault(_ => _.Id.Equals(cacheElem.ProductId));
                    if (k != null)
                        ProductList.Add(new ProductListElement(k, cacheElem.Weight));
                }
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
                CanAddProduct = SelectedProduct != null && SelectedWeight > 0;
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
            set
            {
                SetProperty(ref _selectedWeight, value);
                CanAddProduct = SelectedProduct != null && SelectedWeight > 0;
            }
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
