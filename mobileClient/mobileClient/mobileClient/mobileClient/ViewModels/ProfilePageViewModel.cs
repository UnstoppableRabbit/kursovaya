using System;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public bool IsLogined => CurrentUser.Id != Guid.Empty;

        public bool IsNotLogined => !IsLogined;

        public ProfilePageViewModel()
        {
            UpdateData();
        }

        public void UpdateData()
        {
            CurrentUser = CurrentUser.GetUser();
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
            OnPropertyChanged(nameof(IsLogined));
            OnPropertyChanged(nameof(IsNotLogined));
        }
    }
}