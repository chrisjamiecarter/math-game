// -------------------------------------------------------------------------------------------------
// MathGame.Maui.MauiProgram
// -------------------------------------------------------------------------------------------------
// Creates, configures and runs the Maui application.
// -------------------------------------------------------------------------------------------------
using MathGame.Data;
using Microsoft.Extensions.Logging;

namespace MathGame.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"math-game.db");
            
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                })
                .Services.AddSingleton(s =>
                    ActivatorUtilities.CreateInstance<MathGameDataManager>(s, databaseFilePath)
                );

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
