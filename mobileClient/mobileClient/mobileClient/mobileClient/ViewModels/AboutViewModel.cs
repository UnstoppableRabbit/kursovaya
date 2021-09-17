using System.Windows.Input;
using DataLib.Sqlite;
using DataLib.Sqlite.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Домашняя страница";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}