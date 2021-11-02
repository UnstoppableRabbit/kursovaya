using System;
using System.Net.Http;
using System.Text;
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
    public class RegisterPageViewModel : BaseViewModel
    {
        private string apiUrl = AppData.ApiUrl + "Users/";

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _repeatPassword;
        public string RepeatPassword
        {
            get => _repeatPassword;
            set => SetProperty(ref _repeatPassword, value);
        }
        public DateTime Birthday { get; set; }
        public bool IsMan { get; set; }


        public ICommand RegisterCommand =>
            new Command(async () => await Register());

        private async Task Register()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (Password != RepeatPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Пароли не совпадают", "Попробуйте ввести данные снова", "Ok");
                    return;
                }

                var newUser = new Person
                {
                    Birthday = Birthday,
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    Gender = IsMan,
                    Password = Password
                };

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        await client.PutAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));
                    }
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Попробуйте позже" + e.Message, "Ok");
                }
                await Shell.Current.GoToAsync($"//ProfilePage/{nameof(LoginPage)}");
            }
            else
                await App.Current.MainPage.DisplayAlert("Не удалось выполнить операцию", "Отсутствует подлючение к интернету", "Ok");
        }
    }
}