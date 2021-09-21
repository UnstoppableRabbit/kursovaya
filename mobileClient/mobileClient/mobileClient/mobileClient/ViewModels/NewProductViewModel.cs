using System;
using System.Collections.Generic;
using System.Text;
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

        public bool CanAdd { get => _canAdd; set => SetProperty(ref _canAdd, value); }

        private void CanAddCheck()
        {
            CanAdd = Calories > 0 && !string.IsNullOrEmpty(Name);
        }

        public ICommand AddProductCommand =>
            new Command(() =>
            {
                ProductContext.Database.SaveItem(new Product { Id = ProductContext.Database.NewId(), Calories = (double)this.Calories / 100.0, Name = this.Name});
                Calories = 0;
                Name = null;
            });
    }
}
