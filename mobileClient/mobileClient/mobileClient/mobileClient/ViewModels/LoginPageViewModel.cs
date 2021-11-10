using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using DataLib.Mssql.Models;
using mobileClient.Models;
using mobileClient.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string apiUrl = AppData.ApiUrl + "Users/";

        public string Email { get; set; }
        public string Password { get; set; }
        
        public ICommand LoginCommand =>
            new Command(async () => await Login());

        public async Task Login()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        var user = JsonConvert.DeserializeObject<Person>(await (await client.GetAsync(apiUrl + $"{Email}/{Password}/")).Content.ReadAsStringAsync());
                        if (user == null)
                        {
                            await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Неправильный Email или пароль", "Ok");
                            return;
                        }

                        var curUser = CurrentUser.GetUser();
                        curUser.Id = user.Id;
                        curUser.NickName = user.FirstName + " " + user.LastName;
                        curUser.Email = user.Email;
                        curUser.Birthday = user.Birthday;
                        await Shell.Current.GoToAsync("//ProfilePage");
                    }
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Попробуйте позже" + e.Message, "Ok");
                }
            }
            else
                await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Отсутствует подлючение к интернету", "Ok");
        }
    }
}
