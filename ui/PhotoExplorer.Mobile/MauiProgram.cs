using Microsoft.Extensions.Logging;
using PhotoExplorer.Mobile.Services;
using PhotoExplorer.Shared.Services;

namespace PhotoExplorer.Mobile
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

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddScoped<IPhotoService, PhotoServiceMobile>
                (_ => new PhotoServiceMobile(new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:5205")
                }));
            //builder.Services.AddHttpClient<IPhotoService, PhotoServiceMobile>(client =>
            //{
            //    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            //});

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
