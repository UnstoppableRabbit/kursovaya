using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DataLib.Sqlite.Cache;
using mobileClient.Models;
using mobileClient.Views;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        private CurrentUser _currentUser;
        public CurrentUser CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        public bool IsLogined => ! string.IsNullOrEmpty(CurrentUser.NickName);

        public bool IsNotLogined => !IsLogined;

        public ProfilePageViewModel()
        {
            UpdateData();
        }

        public void UpdateData()
        {
            CurrentUser = CurrentUser.GetUser();
            CurrentUser.GetFromConfig(ref _currentUser);
            OnPropertyChanged(nameof(CurrentUser));
            OnPropertyChanged(nameof(IsLogined));
            OnPropertyChanged(nameof(IsNotLogined));
        }

        public ICommand GoToLoginCommand =>
            new Command(async () => await GoToLogin());

        public async Task GoToLogin()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

        public ICommand GoToRegisterCommand =>
            new Command(async () => await GoToRegister());

        public async Task GoToRegister()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }

        public ICommand LogoutCommand =>
            new Command(Logout);

        public void Logout()
        {
            CurrentUser.Id = Guid.Empty;
            CurrentUser.Avatar = null;
            CurrentUser.Email = null;
            CurrentUser.NickName = null;
            CacheContext.Users.DeleteCache();

            OnPropertyChanged(nameof(IsLogined));
            OnPropertyChanged(nameof(IsNotLogined));
        }
    }
}