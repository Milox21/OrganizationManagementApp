using System.Globalization;
using Microsoft.Extensions.Logging;
using OMPMobileApp.Services;
using Radzen;

namespace OMPMobileApp
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
                });

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            builder.Services.AddSingleton(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7070/")
            });
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddScoped<ThemeService>();

            builder.Services.AddScoped(typeof(ApiConnectionService<>));
            builder.Services.AddScoped<AuthorizationService>();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
