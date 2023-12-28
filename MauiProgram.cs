﻿using sflistviewimageissue.Converters;
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

		//Views
        builder.Services.AddSingleton<Page1Page>();
		builder.Services.AddSingleton<Page2Page>();

        return builder.Build();
	}
}
