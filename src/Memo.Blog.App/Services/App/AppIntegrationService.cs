using Masa.Blazor;
using Memo.Blog.App.Extensions;

namespace Memo.Blog.App.Services.App
{
    public class AppIntegrationService
    {
        private readonly MasaBlazor _masaBlazor;
        private const string AppThemeKey = "AppTheme";

        public AppIntegrationService(MasaBlazor masaBlazor)
        {
            _masaBlazor = masaBlazor;
        }

        public Task InitThemeAsync()
        {
            var result = Preferences.Default.Get<int>(AppThemeKey, -1);
            var isDark = result < 1
                ? Microsoft.Maui.Controls.Application.Current?.RequestedTheme == AppTheme.Dark
                : result == 2;
            _masaBlazor.SetTheme(isDark);

            return Task.CompletedTask;
        }

        public Task SetCacheAsync<T>(string key, T value)
        {
            var type = typeof(T);
            if (type != typeof(string) && type.IsClass)
            {
                var jsonValue = value?.ToJson() ?? string.Empty;
                Preferences.Default.Set(key, jsonValue);
            }
            else
            {
                Preferences.Default.Set(key, value);
            }

            return Task.CompletedTask;
        }

        public Task RemoveCacheAsync(string key)
        {
            Preferences.Default.Remove(key);
            return Task.CompletedTask;
        }

        public Task<T> GetCacheAsync<T>(string key, T defaultValue)
        {
            var type = typeof(T);
            if (type != typeof(string) && type.IsClass)
            {
                var jsonValue = Preferences.Default.Get(key, string.Empty);
                if (string.IsNullOrEmpty(jsonValue))
                {
                    return Task.FromResult(defaultValue);
                }

                return Task.FromResult(jsonValue.ToDesJson<T>() ?? defaultValue);
            }

            return Task.FromResult(Preferences.Default.Get(key, defaultValue));
        }
    }
}
