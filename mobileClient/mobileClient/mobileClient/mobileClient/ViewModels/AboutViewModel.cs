using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using DataLib.Mssql.Models;
using DataLib.Sqlite;
using DataLib.Sqlite.Cache;
using DataLib.Sqlite.Model;
using Java.Util;
using mobileClient.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();
        private static string apiUrl = AppData.ApiUrl + "Posts/";
        public AboutViewModel()
        {
            Title = "Новости";
            GetPostsAsync();
        }

        public ICommand OpenWebCommand { get; }

        public async Task GetPostsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                // ReSharper disable once PossibleNullReferenceException
                foreach (var post in JsonConvert.DeserializeObject<List<Post>>(await (await client.GetAsync(apiUrl)).Content.ReadAsStringAsync()))
                {
                    Posts.Add(post);
                }
            }
        }
    }
}