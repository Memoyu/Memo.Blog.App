using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Models.App;

public class SettingItem
{
    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public EventCallback? OnClick { get; set; }
}
