using Masa.Blazor;
using Serilog.Events;
using Serilog;
using Microsoft.Extensions.Logging;
using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components.Authorization;
using Memo.Blog.App.Services.App;
using Memo.Blog.App.Services;

namespace Memo.Blog.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMasaBlazor(this IServiceCollection services)
    {
        static void optionsAction(MasaBlazorOptions options)
        {
            options.Defaults = new Dictionary<string, IDictionary<string, object?>?>()
            {
                {
                    PopupComponents.SNACKBAR, new Dictionary<string, object?>()
                    {
                        { nameof(PEnqueuedSnackbars.Text), true },
                        { nameof(PEnqueuedSnackbars.Elevation), new StringNumber(2) },
                        { nameof(PEnqueuedSnackbars.Position), SnackPosition.TopCenter }
                    }
                },
                {
                    nameof(MBottomSheet), new Dictionary<string, object?>()
                    {
                        { nameof(MBottomSheet.Eager), true }
                    }
                }
            };
            options.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Surface = "#f7f8f9";
                theme.Themes.Dark.Surface = "#121212";
            });
        }

        var masaBlazorBuilder = services.AddMasaBlazor(optionsAction, ServiceLifetime.Singleton);

        return services;
    }

    public static ILoggingBuilder AddSerilogFile(this ILoggingBuilder logging)
    {
        var flushInterval = new TimeSpan(0, 0, 1);
        var file = Path.Combine(FileSystem.AppDataDirectory, "memo.blog.app.log");

        Log.Logger = new LoggerConfiguration()
                       .MinimumLevel.Information()
                       .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File(file, flushToDiskInterval: flushInterval, encoding: System.Text.Encoding.UTF8, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 22)
            .CreateLogger();

        logging.AddSerilog(dispose: true);

        return logging;
    }

    public static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddAuthorizationCore();

        services.AddScoped<AppAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<AppAuthenticationStateProvider>());

        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<AppIntegrationService>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpClient<AppHttpClient>();

        services.AddScoped<UserService>();

        return services;
    }
}
