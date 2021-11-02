using System.Windows.Input;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class DayNormViewModel : BaseViewModel
    {
        private bool _isMan;
        private bool _isWoman;
        private int _weight;
        private int _height;
        private int _age;

        public bool IsMan
        {
            get => _isMan;
            set => SetProperty(ref _isMan, value);
        }

        public bool IsWoman
        {
            get => _isWoman;
            set => SetProperty(ref _isWoman, value);
        }
        public int Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public ICommand CalcCommand =>
            new Command(param =>
                {
                    App.Current.MainPage.DisplayAlert("Ваша дневная норма калорий:",
                        IsMan
                            ? $"{66.5 + (13.7 * Weight) + (5 * Height) + (6.8 * Age)}"
                            : $"{665 + (9.6 * Weight) + (1.8 * Height) + (4.7 * Age)}", "Ok");
                },
                param => true);

    }
}
