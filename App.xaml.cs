using MauiOnyx.Pages;
using MauiOnyx.ViewModels;

namespace MauiOnyx
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = serviceProvider.GetRequiredService<LoginPage>();
        }
    }
}
