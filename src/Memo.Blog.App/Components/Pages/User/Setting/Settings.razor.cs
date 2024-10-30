using Masa.Blazor.Presets;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.User.Setting;

public partial class Settings
{
    [Inject] AppIntegrationService AppIntegrationService { get; set; } = default!;
    [Inject] PageStackNavController NavController { get; set; } = default!;

    Dictionary<string, List<SettingItem>> _settings = new()
    {
        {
            "应用设置",
            new List<SettingItem>
            {
                new() { Title = "颜色主题", Path="/settings/theme-mode" },
                new() { Title = "清理缓存", Subtitle= "999.9 KB" }
            }
        },
        {
            "测试",
            new List<SettingItem>
            {
                new() { Title = "占位" }
            }
        }
    };

    bool _settingItemClick = false;

    private async Task HandleSetting(SettingItem item)
    {
        _settingItemClick = true;
        if (!string.IsNullOrWhiteSpace(item.Path))
        {
            NavController.Push(item.Path);
        }

        if (item.OnClick is not null)
        {
           await item.OnClick.Value.InvokeAsync();
        }
        _settingItemClick = false;
    }
}
