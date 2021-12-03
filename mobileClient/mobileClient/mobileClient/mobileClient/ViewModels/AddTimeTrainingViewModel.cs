using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DataLib.Sqlite;
using DataLib.Sqlite.Cache;
using DataLib.Sqlite.Model;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class AddTimeTrainingViewModel : BaseViewModel
    {
        private List<Training> allTrainings;
        public AddTimeTrainingViewModel()
        {
            Trainings = new ObservableCollection<Training>();
        }

        public bool IsButtonEnabled
        {
            get
            {
                int x;
                return SelectedItem != null && int.TryParse(Points, out x) && x > 0;
            }
        }

        private Training selectedItem;
        public Training SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        private string type;
        public string Type
        {
            get => type;
            set
            {
                SetProperty(ref type, value);
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        public string PlaceholderText => Type == "Упражнения на время" ? "Секунды" : "Повторения";

        private string itemId;
        public string ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        private string points;
        public string Points
        {
            get => points;
            set
            {
                SetProperty(ref points, value);
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnSearch(value);
                SetProperty(ref searchText, value);
            }
        }

        public ObservableCollection<Training> Trainings { get; set; }

        public ICommand AddCommand =>
            new Command(() =>
            {
                if (Points == null)
                    return;
                CacheContext.TrainingCache.SaveItem(new TrainingCache
                {
                    TrainingId = SelectedItem.Id,
                    Points = int.Parse(Points),
                    Calories = SelectedItem.Calories
                });
                SelectedItem = null;
                Points = null;
            });


        private void OnSearch(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                Trainings.Clear();
                foreach (var tr in allTrainings)
                {
                    Trainings.Add(tr);
                }
            }
            else
            {
                Trainings.Clear();
                foreach (var tr in allTrainings.Where(_ => _.Name.ToUpperInvariant().Contains(obj.ToUpperInvariant())))
                {
                    Trainings.Add(tr);
                }
            }
        }

        public void LoadItemId(string itemId)
        {
            try
            {
                Type = itemId;
                if (Type == "Упражнения на время")
                {
                    allTrainings = ProductContext.Trainings.GetItems()
                        .Where(_ => !_.IsRepeated).ToList();
                    Trainings.Clear();
                    foreach (var tr in allTrainings)
                    {
                        Trainings.Add(tr);
                    }
                }
                else
                {
                    allTrainings = ProductContext.Trainings.GetItems()
                        .Where(_ => _.IsRepeated).ToList();
                    Trainings.Clear();
                    foreach (var tr in allTrainings)
                    {
                        Trainings.Add(tr);
                    }
                }
                OnPropertyChanged(nameof(PlaceholderText));
            }
            catch
            {
                //zxc
            }
        }
    }
}