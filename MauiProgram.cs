using MauiOnyx.API;
using MauiOnyx.Pages;
using MauiOnyx.Services;
using MauiOnyx.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiOnyx
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<ScheduleViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SchedulePage>();

            builder.Services.AddTransient<AppShell>();

            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddSingleton<IAlertService, AlertService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
