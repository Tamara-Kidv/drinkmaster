using DrinkMaster.Pages;
using DrinkMaster.ViewModels;

using CommunityToolkit.Maui;

namespace DrinkMaster;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Initialise the toolkit
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<StartPage>();

        builder.Services.AddTransient<PlayerInputPage>();
        builder.Services.AddTransient<PlayerInputViewModel>();

        return builder.Build();

    }
}
