using System.Collections.ObjectModel;
using System.Windows.Input;
using DataLib.Sqlite.Cache;
using mobileClient.Helpers;
using mobileClient.Models;
using mobileClient.Views;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class TrainingPageViewModel : BaseViewModel
    {
        public ObservableCollection<TrainingListElement> TrainingList { get; set; }

        public ObservableCollection<CarouselElement> CarouselElements { get; set; }

        public TrainingPageViewModel()
        {
            TrainingList = new ObservableCollection<TrainingListElement>(CacheContext.TrainingCache.GetItems().ToListTraningElement());
            CarouselElements = new ObservableCollection<CarouselElement>
            {
                new CarouselElement {Image = "kachaetsa.png", Name = "Упражнения на повторения"},
                new CarouselElement {Image = "begaet.png", Name = "Упражнения на время"}
            };
        }

        public bool CanClear => TrainingList.Count > 0;

        public bool CanDelete => SelectedItem != null;

        private TrainingListElement selectedItem;
        public TrainingListElement SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnPropertyChanged(nameof(CanDelete));
            }
        }

        public void Refresh()
        {
            TrainingList.Clear();
            foreach (var el in CacheContext.TrainingCache.GetItems().ToListTraningElement())
            {
                TrainingList.Add(el);
            }
            OnPropertyChanged(nameof(CanClear));
        }
        public ICommand ClearProductCommand =>
            new Command(() =>
            {
                TrainingList.Clear();
                CacheContext.TrainingCache.DeleteCache();
                SelectedItem = null;
                OnPropertyChanged(nameof(CanClear));
            });

        public ICommand DeleteCurrentCommand =>
            new Command(() =>
            {
                TrainingList.Remove(SelectedItem);
                CacheContext.TrainingCache.DeleteItem(SelectedItem.Id);
                SelectedItem = null;
                OnPropertyChanged(nameof(CanClear));
            });

        public ICommand PlusClickCommand =>
            new Command(PlusClick);

        private async void PlusClick(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTrainingPage));
        }

        public Command<CarouselElement> ItemTapped => new Command<CarouselElement>(OnAddItem);

        private async void OnAddItem(CarouselElement ce)
        {
            if (ce == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(AddTimeTraining)}?{nameof(AddTimeTrainingViewModel.ItemId)}={ce.Name}");
        }
    }
}
