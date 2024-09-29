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
            // 全局默认配置
            options.Defaults = new Dictionary<string, IDictionary<string, object?>?>()
            {
                [nameof(MButton)] = new Dictionary<string, object?>()
                {
                    [nameof(MButton.Depressed)] = true
                },

                [nameof(MSheet)] = new Dictionary<string, object?>()
                {
                    ["Rounded"] = (StringBoolean)true,
                },
                ["MTextField"] = new Dictionary<string, object?>()
                {
                    ["Filled"] = true,
                    ["Rounded"] = true,
                    ["PersistentPlaceholder"] = true
                },
                [nameof(MTextarea)] = new Dictionary<string, object?>()
                {
                    ["Filled"] = true,
                    ["Rounded"] = true,
                    ["PersistentPlaceholder"] = true
                },
                [PopupComponents.SNACKBAR] = new Dictionary<string, object?>()
                {
                    { nameof(PEnqueuedSnackbars.Text), true },
                    { nameof(PEnqueuedSnackbars.Elevation), new StringNumber(2) },
                    { nameof(PEnqueuedSnackbars.Position), SnackPosition.TopCenter }
                },
                [nameof(MImage)] = new Dictionary<string, object?>()
                {
                    // https://github.com/masastack/MASA.Blazor/issues/1624
                    [nameof(MImage.Eager)] = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS()
                },
                [nameof(MBottomSheet)] = new Dictionary<string, object?>()
                {
                    { nameof(MBottomSheet.Eager), true }
                }
            };

            options.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4f33ff";
                theme.Themes.Light.Secondary = "#5e5c71";
                // theme.Themes.Light.Accent = "#006C4F";
                theme.Themes.Light.Error = "#BA1A1A";
                theme.Themes.Light.Surface = "#f0f3fa";
                theme.Themes.Light.OnSurface = "#1C1B1F";
                theme.Themes.Light.InverseSurface = "#131316";
                theme.Themes.Light.InverseOnSurface = "#C9C5CA";
                theme.Themes.Light.InversePrimary = "#C5C0FF";

                theme.Themes.Dark.Primary = "#C5C0FF";
                // theme.Themes.Dark.OnPrimary = "#090029";
                theme.Themes.Dark.Secondary = "#C7C4DC";
                theme.Themes.Dark.OnSecondary = "#302E42";
                theme.Themes.Dark.Accent = "#67DBAF";
                theme.Themes.Dark.OnAccent = "#003827";
                theme.Themes.Dark.Error = "#FFB4AB";
                theme.Themes.Dark.OnError = "#690005";
                theme.Themes.Dark.Surface = "#131316";
                theme.Themes.Dark.OnSurface = "#C9C5CA";
                theme.Themes.Dark.InverseOnSurface = "#1C1B1F";
                theme.Themes.Dark.InversePrimary = "#4f33ff";
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
