using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components;

public partial class TopTabs
{
    [Parameter] public StringNumber? Value { get; set; }

    [Parameter] public EventCallback<StringNumber?> ValueChanged { get; set; }

    [Parameter] public List<TabItem> Items { get; set; } = [];
}
