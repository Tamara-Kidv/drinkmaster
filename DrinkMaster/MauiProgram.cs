using CommunityToolkit.Maui;
using DrinkMaster.Pages;
using DrinkMaster.ViewModels;

namespace DrinkMaster;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        // Initialise the toolkit
        _ = builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        _ = builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                _ = fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                _ = fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        _ = builder.Services.AddTransient<StartPage>();

        _ = builder.Services.AddTransient<PlayerInputPage>();
        _ = builder.Services.AddTransient<PlayerInputViewModel>();

        return builder.Build();

    }
}
