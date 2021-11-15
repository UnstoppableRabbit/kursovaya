using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataLib.Sqlite;
using DataLib.Sqlite.Cache;
using DataLib.Sqlite.Model;
using mobileClient.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<News> News { get; set; } = new ObservableCollection<News>();
        public AboutViewModel()
        {
            Title = "Новости";
            News.Add(new News()
            {
                DateTime = DateTime.Now,
                Title = "Внимание",
                Text = "Крутая новость",
                Foto = "https://www.nastol.com.ua/download.php?img=201701/1600x1200/nastol.com.ua-201325.jpg"
            });
        }

        public ICommand OpenWebCommand { get; }
    }
}