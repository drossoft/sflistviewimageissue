using FFImageLoading.Maui;
using sflistviewimageissue.Converters;
using sflistviewimageissue.Repository;
using sflistviewimageissue.Services;
using Syncfusion.Maui.Core.Hosting;

namespace sflistviewimageissue;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureSyncfusionCore()
            .UseFFImageLoading()
            .UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Converters
        builder.Services.AddSingleton<AccountImageIndexToImageSourceConverter>();

        //Services
        builder.Services.AddSingleton<DatabaseService>();

		//Repository
        builder.Services.AddSingleton<GlobalDataRepository>();

		//ViewModels
        builder.Services.AddSingleton<Page1ViewModel>();
        builder.Services.AddSingleton<Page2ViewModel>();
        builder.Services.AddSingleton<ReportsViewModel>();

        //Views
        builder.Services.AddSingleton<Page1Page>();
		builder.Services.AddSingleton<Page2Page>();
        builder.Services.AddSingleton<ReportsPage>();

        return builder.Build();
	}
}
