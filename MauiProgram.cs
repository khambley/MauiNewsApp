using Microsoft.Extensions.Logging;

namespace MauiNewsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("FontAwesome6Pro-Solid-900.otf", "FontAwesome");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .RegisterAppTypes();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
    public static MauiAppBuilder RegisterAppTypes(this MauiAppBuilder mauiAppBuilder)
    {
        // ViewModels
        mauiAppBuilder.Services.AddTransient<ViewModels.HeadlinesViewModel>();

        // Views
        mauiAppBuilder.Services.AddTransient<Views.AboutView>();
        mauiAppBuilder.Services.AddTransient<Views.ArticleView>();
        mauiAppBuilder.Services.AddTransient<Views.HeadlinesView>();

        return mauiAppBuilder;
    }
}

