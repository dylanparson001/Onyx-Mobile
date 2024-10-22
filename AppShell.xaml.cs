using MauiOnyx.Pages;
using MauiOnyx.ViewModels;

namespace MauiOnyx
{
    public partial class AppShell : Shell
    {
        private readonly IServiceProvider _serviceProvider;

        public AppShell(AppShellViewModel viewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = viewModel;

            _serviceProvider = serviceProvider;

            Navigating += OnShellNavigating;

            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("SchedulePage", typeof(SchedulePage));
            Routing.RegisterRoute("JobListPage", typeof(JobListPage));
        }

        private void OnShellNavigating(object? sender, ShellNavigatingEventArgs e)
        {
            if (e.Target.Location.OriginalString == "LoginPage")
            {
                e.Cancel();
                Logout();

            }
        }

        private void Logout()
        {
            Application.Current.MainPage = _serviceProvider.GetRequiredService<LoginPage>();
        }
    }
}
