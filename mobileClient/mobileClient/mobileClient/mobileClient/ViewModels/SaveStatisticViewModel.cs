using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataLib.Mssql.Models;
using mobileClient.Models;
using mobileClient.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class SaveStatisticViewModel : BaseViewModel
    {
        private string apiUrl = AppData.ApiUrl + "Statistic/";

        private int eatenCalories;
        public int EatenCalories
        {
            get => eatenCalories;
            set => SetProperty(ref eatenCalories, value);
        }

        private double burntCalories;
        public double BurntCalories
        {
            get => burntCalories;
            set => SetProperty(ref burntCalories, value);
        }

        private int currentWeight;
        public int CurrentWeight
        {
            get => currentWeight;
            set => SetProperty(ref currentWeight, value);
        }

        public Command SaveStatisticCommand => new Command(async () => await SaveStatisticAsync());

        private async Task SaveStatisticAsync()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (CurrentWeight > 300 || CurrentWeight < 10)
                {
                    await App.Current.MainPage.DisplayAlert("Не тролль", "Че с весом xD", "Извиняюсь");
                    return;
                }

                var cu = CurrentUser.GetUser();
                CurrentUser.GetFromConfig(ref cu);
                var newLog = new PersonSportLog()
                {
                   Id = Guid.NewGuid(),
                   Date =  DateTime.Now,
                   Weight = CurrentWeight,
                   PersonId = cu.Id
                };

                var newStat = new Diet()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    TotalCalories = EatenCalories - BurntCalories,
                    PersonId = cu.Id
                };

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        await client.PutAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(newStat), Encoding.UTF8, "application/json"));
                        await client.PostAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(newLog), Encoding.UTF8, "application/json"));
                    }
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Попробуйте позже" + e.Message, "Ok");
                }
                await Shell.Current.GoToAsync($"//StatisticPage");
            }
            else
                await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Отсутствует подлючение к интернету", "Ok");
        }
    }
}
