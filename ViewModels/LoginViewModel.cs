using CommunityToolkit.Mvvm.ComponentModel;
using MauiOnyx.Interfaces;
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

            //Task.Run(async () =>
            //{
            //    await CheckToken();
            //});

            try
            {
                string companyId = Preferences.Default.Get("CompanyId", "");
                if (!string.IsNullOrEmpty(companyId))
                {
                    CompanyId = companyId;
                }
            }
            catch (Exception ex)
            {
                _alertService.Alert(ex.Message, "Error", "OK");
            }
        }
        private async Task CheckToken()
        {
            var Ip = Preferences.Default.Get("ApiUri", "");
            if (string.IsNullOrEmpty(Ip))
            {
                return;
            }
            try
            {
                var token = Preferences.Default.Get("Token", "");
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri($"{Ip}");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var response = await httpClient.GetAsync("User/CheckStatus");
                if (response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                {
                    AppShellViewModel appShellViewModel = _serviceProvider.GetRequiredService<AppShellViewModel>();
                    Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async void LoginButtonClicked(object obj)
        {
            if (string.IsNullOrEmpty(Username))
            {
                _alertService.Alert("Enter your username", "Error", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                _alertService.Alert("Enter your password", "Error", "OK");
                return;
            }
            if (string.IsNullOrEmpty(CompanyId))
            {
                _alertService.Alert("Enter your Company ID", "Error", "OK");
                return;
            }

            User user = new User();
            try
            {
                user = await _loginService.Login(Username, Password, CompanyId);
                if (user == null)
                {
                    _alertService.Alert("Incorrect Credentials", "Incorrect Login", "OK");

                    return;
                }
                Preferences.Default.Set("Token", user.Token);
                Preferences.Default.Set("CompanyId", user.CompanyId);
                Preferences.Default.Set("Role", user.Role);
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
