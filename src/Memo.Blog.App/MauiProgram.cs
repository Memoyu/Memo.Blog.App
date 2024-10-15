using CommunityToolkit.Maui;
using Memo.Blog.App.Extensions;
using Microsoft.Extensions.Logging;

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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG

#if WINDOWS
            // windows 下解决Mixed Content问题（）
            Environment.SetEnvironmentVariable("WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", "--disable-features=AutoupgradeMixedContent");
#endif

            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddMasaBlazor();

            builder.Logging.AddSerilogFile();

            // builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddAuthorization();

            builder.Services.AddAppServices();
            builder.Services.AddServices();

            return builder.Build();
        }
    }
}
