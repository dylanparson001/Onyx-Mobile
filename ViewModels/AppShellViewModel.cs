using CommunityToolkit.Mvvm.ComponentModel;
using MauiOnyx.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiOnyx.ViewModels
{
    public class AppShellViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        public ICommand LogoutCommand { get; }

        public AppShellViewModel(IServiceProvider serviceProvider)
        {
            LogoutCommand = new Command(LogoutButtonClicked);
            _serviceProvider = serviceProvider;
        }


        private void LogoutButtonClicked(object obj)
        {
            Preferences.Default.Remove("Token");
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();
            Application.Current.MainPage = new LoginPage(loginViewModel);
        }
    }
}
