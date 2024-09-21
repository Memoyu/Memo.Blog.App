using CommunityToolkit.Maui;
using Memo.Blog.App.Extensions;
using Memo.Blog.App.Models.App;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace Memo.Blog.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddMasaBlazor();

            builder.Logging.AddSerilogFile();

            // builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddAuthorization();

            builder.Services.AddServices(builder.Configuration);

            return builder.Build();
        }
    }
}
