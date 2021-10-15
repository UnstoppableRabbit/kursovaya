using System.Collections.ObjectModel;
using DataLib.Sqlite;
using DataLib.Sqlite.Model;
using mobileClient.Models;
using mobileClient.Views;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class TrainingPageViewModel : BaseViewModel
    {
        public ObservableCollection<Training> TrainingList { get; set; }

        public ObservableCollection<CarouselElement> CarouselElements { get; set; }

        public TrainingPageViewModel()
        {
            TrainingList = new ObservableCollection<Training>(ProductContext.Trainings.GetItems());
            CarouselElements = new ObservableCollection<CarouselElement>
            {
                new CarouselElement {Image = "kachaetsa.png", Name = "Упражнения на повторения"},
                new CarouselElement {Image = "begaet.png", Name = "Упражнения на время"}
            };
        }

        public Command<CarouselElement> ItemTapped => new Command<CarouselElement>(OnAddItem);

        private async void OnAddItem(CarouselElement ce)
        {
            if (ce == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(AddTimeTraining)}?{nameof(AddTimeTrainingViewModel.ItemId)}={ce.Name}");
        }
    }
}
