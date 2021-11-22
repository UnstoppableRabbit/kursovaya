using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using DataLib.Mssql.Models;
using mobileClient.Models;
using Newtonsoft.Json;

namespace mobileClient.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        private bool isPostVisible;

        public bool IsPostVisible
        {
            get => isPostVisible;
            set => SetProperty(ref isPostVisible, value, nameof(IsPostVisible));
        }

        public bool IsNotPostVisible => !IsPostVisible;


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
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    Posts.Clear();
                    // ReSharper disable once PossibleNullReferenceException
                    foreach (var post in JsonConvert.DeserializeObject<List<Post>>(
                        await (await client.GetAsync(apiUrl)).Content.ReadAsStringAsync()))
                    {
                        Posts.Add(post);
                    }
                }

                IsPostVisible = true;
                OnPropertyChanged(nameof(IsNotPostVisible));
            }
            catch
            {
                IsPostVisible = false;
                OnPropertyChanged(nameof(IsNotPostVisible));
            }
        }
    }
}