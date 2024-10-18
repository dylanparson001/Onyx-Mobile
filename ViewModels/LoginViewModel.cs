using CommunityToolkit.Mvvm.ComponentModel;
using MauiOnyx.API;
using MauiOnyx.Models;
using MauiOnyx.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiOnyx.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public ICommand LoginCommand { get; set; }
        public string AppTitle { get; } = "Onyx";

        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        private readonly IAlertService _alertService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoginService _loginService;

        public LoginViewModel(IAlertService alertService, IServiceProvider serviceProvider, ILoginService loginService)
        {
            LoginCommand = new Command(LoginButtonClicked);
            _alertService = alertService;
            _serviceProvider = serviceProvider;
            _loginService = loginService;
        }

        private async void LoginButtonClicked(object obj)
        {
            User user = new User();
            try
            {
                user = await _loginService.Login(Username, Password, CompanyId);
                if (user == null)
                {
                    _alertService.Alert("Incorrect Credentials", "Incorrect Login", "OK");

                    return;
                }
            } 
            catch (Exception ex)
            {
                _alertService.Alert(ex.Message, "Error", "OK");
                return;
            }

            AppShellViewModel appShellViewModel = _serviceProvider.GetRequiredService<AppShellViewModel>();
            Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();
        }
    }
}
