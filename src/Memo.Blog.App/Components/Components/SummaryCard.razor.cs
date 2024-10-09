using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components;

public partial class SummaryCard
{
    private static int defaultColumns = 3;

    private int rows => Items.Count / columns;

    private int columns => Columns?.ToInt32() ?? defaultColumns;

    [Parameter] public StringNumber? Columns { get; set; } = defaultColumns;

    [Parameter] public List<SummaryCardItem> Items { get; set; } = [];

    [Parameter] public EventCallback<List<SummaryCardItem>> ItemsChanged { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        StateHasChanged();
    }
}
