using Microsoft.Extensions.Logging;
using LamaranKerjaOnline.Data;
using DevExpress.Blazor;
using LamaranKerjaOnline.Service;

namespace LamaranKerjaOnline;

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

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		// Register WeatherForecastService and the SQLite database
		builder.Services.AddSingleton<UserService>(
			s => ActivatorUtilities.CreateInstance<UserService>(s, Constants.DatabasePath));
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<BarangService>();
		builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
		return builder.Build();
	}
}
