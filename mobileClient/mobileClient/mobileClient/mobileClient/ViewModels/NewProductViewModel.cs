using System.Collections.ObjectModel;
using System.Windows.Input;
using DataLib.Sqlite;
using DataLib.Sqlite.Model;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class NewProductViewModel : BaseViewModel
    {
        private int _calories;
        private string _name;
        private bool _canAdd;
        private bool _canDelete;
        private Product _deleted;

        public NewProductViewModel()
        {
            AllProducts = new ObservableCollection<Product>(ProductContext.Products.GetItems());
        }

        public ObservableCollection<Product> AllProducts { get; set; }
        public int Calories
        {
            get => _calories;
            set
            {
                SetProperty(ref _calories, value);
                CanAddCheck();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                CanAddCheck();
            }
        }

        public Product Deleted
        {
            get => _deleted;
            set
            {
                SetProperty(ref _deleted, value);
                CanDelete = value != null && value.Id > 0;
            }
        }

        public bool CanAdd { get => _canAdd; set => SetProperty(ref _canAdd, value); }
        public bool CanDelete { get => _canDelete; set => SetProperty(ref _canDelete, value); }

        private void CanAddCheck()
        {
            CanAdd = Calories > 0 && !string.IsNullOrEmpty(Name);
        }

        public ICommand AddProductCommand =>
            new Command(() =>
            {
                var np = new Product
                    { Id = ProductContext.Products.NewId(), Calories = (double) this.Calories / 100.0, Name = this.Name };
                ProductContext.Products.SaveItem(np);
                AllProducts.Add(np);
                Calories = 0;
                Name = null;
                CanAddCheck();
            });

        public ICommand DeleteProductCommand =>
            new Command(() =>
            {
                ProductContext.Products.DeleteItem(Deleted.Id);
                AllProducts.Remove(Deleted);
                Deleted = null;
                CanDelete = false;
            });
    }
}
