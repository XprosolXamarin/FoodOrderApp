using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FoodOrderApp.Services;
using Xamarin.Essentials;
using FoodOrderApp.Views;

namespace FoodOrderApp.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;

                OnPropertyChanged();
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;

                OnPropertyChanged();
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;

                OnPropertyChanged();
            }
        }
        private bool _Result;
        public bool Result
        {
            get { return _Result; }
            set
            {
                _Result = value;

                OnPropertyChanged();
            }
        }
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var UserService = new UserService();
                Result = await UserService.RegisterUser(Username, Password);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucess", "User Registered", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Sucess", "User already exists with this credentails","OK");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var UserService = new UserService();
                Result = await UserService.LoginUser(Username, _Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
